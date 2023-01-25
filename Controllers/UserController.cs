using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using react_red.interfaces;
using react_red.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

 

namespace react_red.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUser _userDataAccess;
        private readonly IConfiguration configuration;
        UserController(IUser _userDataAccess,IConfiguration configuration)
        {
            this._userDataAccess = _userDataAccess;
            this.configuration = configuration;
        }

        [HttpGet("/login")]
        public IActionResult Login([FromBody] ILogin login)
        {
            try
            {
                var user = _userDataAccess.Login(login);
                if (user == null) return Forbid();
                else
                {
                    user.Password = "";
                    user.Token = createJWT(user.UsersId, user.Role);
                    return Ok(user);
                }
                          
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/register")]
        public IActionResult Register([FromBody] User _user)
        {
            try
            {
                _userDataAccess.Register(_user);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("/user/{id}")]
        public IActionResult GetAllUsers(Guid id)
        {
            try
            {
                User? _user = _userDataAccess.GetUser(id);
                return (_user == null) ? NotFound() : Ok(_user);
               
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/user/{id}/admin")]
        [Authorize(Roles ="admin")]
        public IActionResult MakeAdmin(Guid id)
        {
            try
            {
                return (_userDataAccess.MakeAdmin(id))?Ok():NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/user/{id}")]
        public IActionResult UpdateUser([FromBody] User user ) {
            try
            {
                User? _user = _userDataAccess.UpdateUser(user);
                return (_user == null) ? NotFound() : Ok(_user);
            }
            catch
            {
                return BadRequest();
            }
        }

        private string createJWT(Guid id,string role)
        {
            SymmetricSecurityKey securityKey = new (Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            SigningCredentials creds = new(securityKey,SecurityAlgorithms.HmacSha256);
            Claim[] claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };
            JwtSecurityToken token = new(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims,
                expires: DateTime.Now.AddDays(20),
                signingCredentials: creds
                );
            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
    }
}
