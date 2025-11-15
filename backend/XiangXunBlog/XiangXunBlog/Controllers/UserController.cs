using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XiangXunBlog.Dtos;
using XiangXunBlog.Repositories;
using XiangXunBlog.Services;

namespace XiangXunBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;



        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //{
        //    var users = await _userService.GetAllUsersAsync();
        //    return Ok(users);
        //}

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            bool res = await _userService.RegisterUser(userDto);
            if (res)
                return Ok(new { message = "注册成功!" });
            else
                return BadRequest(new { message = "注册失败,用户名已经存在!" });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var res = await _userService.LoginUser(userDto);
            if (res == null)
            {
                return Unauthorized(new { message = "用户名或密码错误" });
            }
            else
            {
                return Ok(new { token = res });
            }
        }


        //public UserController(ILogger<UserController> logger)
        //{
        //    _logger = logger;
        //}


    }
}
