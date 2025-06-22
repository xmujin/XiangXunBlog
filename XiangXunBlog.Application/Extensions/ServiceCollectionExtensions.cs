using Microsoft.Extensions.DependencyInjection;
using XiangXunBlog.Application.MyBlog;

namespace XiangXunBlog.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
        }
    }
}
