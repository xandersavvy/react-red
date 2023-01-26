using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using react_red.DataAccess;
using react_red.interfaces;
using react_red.Model;
using System.Text;
var EnvPol = "_envPol";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<BlogContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<IPost, PostDataAccess>();
builder.Services.AddScoped<IPostDownvote, PostDownvoteDataAccess>();
builder.Services.AddScoped<IPostUpvote, PostUpvoteDataAccess>();
builder.Services.AddScoped<IUser, UserDataAccess>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: EnvPol, builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod()
                .SetIsOriginAllowed(SeekOrigin => true).AllowCredentials();
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseCors(EnvPol);
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();





app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
