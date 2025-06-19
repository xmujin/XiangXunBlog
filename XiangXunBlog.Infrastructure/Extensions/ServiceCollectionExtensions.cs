﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XiangXunBlog.Infrastructure.Persistence;

namespace XiangXunBlog.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AdminDbContext>(options => options.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString)));

    }
}
