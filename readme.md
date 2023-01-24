# Scaffold - db

````powershell
dotnet ef dbcontext scaffold "Server=.\;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Model
````
