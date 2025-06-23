using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XiangXunBlog.Application.Extensions;
using XiangXunBlog.Infrastructure.Extensions;

namespace XiangXunBlog.API
{
    public class Message
    {
        public string Text { get; set; }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder
                .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                        ),
                    };
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers(); // Ó³Éäcontroller

            //app.MapPost(
            //    "/login",
            //    (UserLogin login, IConfiguration config) =>
            //    {
            //        if (login.Username != "admin" || login.Password != "123456")
            //            return Results.Unauthorized();

            //        var claims = new[]
            //        {
            //            new Claim(ClaimTypes.Name, login.Username),
            //            new Claim(ClaimTypes.Role, "admin"),
            //        };

            //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //        var token = new JwtSecurityToken(
            //            issuer: config["Jwt:Issuer"],
            //            audience: config["Jwt:Audience"],
            //            claims: claims,
            //            expires: DateTime.UtcNow.AddMinutes(120),
            //            signingCredentials: creds
            //        );

            //        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //        return Results.Ok(new { token = jwt });
            //    }
            //);

            app.MapGet(
                    "/secure",
                    (HttpContext context) =>
                    {
                        var userName = context.User.Identity?.Name;
                        return $"Hello {userName}, this is a protected API.";
                    }
                )
                .RequireAuthorization();

            app.Run();
        }
    }
}
