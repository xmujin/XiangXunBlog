using Microsoft.EntityFrameworkCore;
using XiangXunBlog.Domain.Entities;

namespace XiangXunBlog.Infrastructure.Persistence
{
    internal class AdminDbContext(DbContextOptions<AdminDbContext> options) : DbContext(options)
    {
        internal DbSet<Admin> Admin { get; set; }






    }
}
