using XiangXunBlog.Domain.Entities;

namespace XiangXunBlog.Domain.Repositories
{

    /// <summary>
    /// 能够通过该接口获取Admin表中的数据
    /// </summary>
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAsync();

        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <param name="admin">传入的管理员信息对象</param>
        /// <returns></returns>
        Task AddAsync(Admin admin);

        /// <summary>
        /// 通过管理员用户名返回管理员信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Task<Admin?> GetByUserNameAsync(string userName);
    }
}
