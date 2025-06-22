using XiangXunBlog.Domain.Entities;

namespace XiangXunBlog.Domain.Repositories
{

    /// <summary>
    /// 能够通过该接口获取Admin表中的数据
    /// </summary>
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAsync();
    }
}
