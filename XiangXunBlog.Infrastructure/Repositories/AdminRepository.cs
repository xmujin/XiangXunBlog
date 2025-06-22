using Microsoft.EntityFrameworkCore;
using XiangXunBlog.Domain.Entities;
using XiangXunBlog.Domain.Repositories;
using XiangXunBlog.Infrastructure.Persistence;

namespace XiangXunBlog.Infrastructure.Repositories
{


    /// <summary>
    /// 该类用于实现Domain中的IAdminRepository接口
    /// </summary>
    /// <param name="dbContext"></param>
    internal class AdminRepository(AdminDbContext dbContext) : IAdminRepository
    {
        public async Task<IEnumerable<Admin>> GetAllAsync()
        {

            var myAdmin = await dbContext.Admins.ToListAsync();
            return myAdmin;
        }
    }
}
