using Microsoft.Extensions.Logging;
using XiangXunBlog.Domain.Entities;
using XiangXunBlog.Domain.Repositories;

namespace XiangXunBlog.Application.MyBlog
{
    internal class AdminService(IAdminRepository adminRepository, ILogger<AdminService> logger) : IAdminService
    {

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            logger.LogInformation("get admin");
            var admins = await adminRepository.GetAllAsync();
            return admins;
        }

    }
}
