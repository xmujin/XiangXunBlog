using Microsoft.Extensions.Logging;
using XiangXunBlog.Application.Security;
using XiangXunBlog.Domain.Entities;
using XiangXunBlog.Domain.Repositories;

namespace XiangXunBlog.Application.MyBlog
{
    internal class AdminService(IAdminRepository adminRepository,
        IPasswordHasher passwordHasher,
        ILogger<AdminService> logger) : IAdminService
    {

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            logger.LogInformation("get admin");
            var admins = await adminRepository.GetAllAsync();
            return admins;

        }

        public async Task<bool> LoginAsync(string username, string password)
        {


            Admin admin = await adminRepository.GetByUserNameAsync(username);

            if (admin == null)
            {
                return false; // 用户不存在，登录失败
            }
            bool valid = passwordHasher.Verify(password, admin.PasswordHash);
            return valid;
        }

        public async Task RegisterAsync(string username, string password)
        {
            string passwordHash = passwordHasher.Hash(password);
            Admin admin = new Admin
            {
                UserName = username,
                PasswordHash = passwordHash

            };
            await adminRepository.AddAsync(admin);
        }
    }
}
