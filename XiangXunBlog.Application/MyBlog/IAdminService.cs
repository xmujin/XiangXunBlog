using XiangXunBlog.Domain.Entities;

namespace XiangXunBlog.Application.MyBlog
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
    }
}