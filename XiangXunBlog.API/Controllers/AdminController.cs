using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XiangXunBlog.Application.Dtos;
using XiangXunBlog.Application.MyBlog;

namespace XiangXunBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController(IAdminService adminService, IConfiguration configuration) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admins = await adminService.GetAllAdmins();
            return Ok(admins);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AdminDto login)
        {
            await adminService.RegisterAsync(login.Username, login.Password);
            return Ok("注册成功");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminDto adminDto)
        {
            bool sb = await adminService.LoginAsync(adminDto.Username, adminDto.Password);
            if (!sb)
            {
                return Unauthorized("用户名密码错误");
            }

            var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, adminDto.Username),
                        new Claim(ClaimTypes.Role, "admin"),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = jwt });
        }
    }
}
