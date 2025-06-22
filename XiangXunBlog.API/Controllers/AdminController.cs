using Microsoft.AspNetCore.Mvc;
using XiangXunBlog.Application.MyBlog;

namespace XiangXunBlog.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class AdminController(IAdminService adminService) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var admins = await adminService.GetAllAdmins();
            return Ok(admins);
        }






    }
}
