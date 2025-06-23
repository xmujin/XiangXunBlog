using XiangXunBlog.Domain.Entities;

namespace XiangXunBlog.Application.MyBlog
{

    /// <summary>
    /// 管理员的登录注册服务
    /// </summary>
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();


        /// <summary>
        /// 注册管理员账户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task RegisterAsync(string username, string password);


        /// <summary>
        /// 登录管理员账户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<bool> LoginAsync(string username, string password);





    }
}