using Microsoft.EntityFrameworkCore;
using XiangXunBlog.Domain.Entities;

namespace XiangXunBlog.Infrastructure.Persistence
{



    /// <summary>
    /// 该类用于获取数据库上下文
    /// </summary>
    /// <param name="options"></param>
    internal class AdminDbContext(DbContextOptions<AdminDbContext> options) : DbContext(options)
    {
        internal DbSet<Admin> Admins { get; set; }
    }
}
