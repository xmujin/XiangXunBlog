using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XiangXunBlog.Domain.Repositories;
using XiangXunBlog.Infrastructure.Persistence;
using XiangXunBlog.Infrastructure.Repositories;

namespace XiangXunBlog.Infrastructure.Extensions;
/// <summary>
/// 该类用于扩展基础设施，通过依赖注入使其他类能够使用
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AdminDbContext>(options => options.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IAdminRepository, AdminRepository>();

    }
}
