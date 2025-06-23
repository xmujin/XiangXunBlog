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



        public async Task AddAsync(Admin admin)
        {
            await dbContext.Admins.AddAsync(admin);
            await dbContext.SaveChangesAsync(); // 保存数据
        }
        /// <summary>
        /// 用于获取
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Admin>> GetAllAsync()
        {

            var myAdmin = await dbContext.Admins.ToListAsync();
            return myAdmin;
        }

        public async Task<Admin?> GetByUserNameAsync(string userName)
        {
            return await dbContext.Admins.
                FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
