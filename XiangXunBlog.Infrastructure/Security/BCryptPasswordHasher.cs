
using XiangXunBlog.Application.Security;

namespace XiangXunBlog.Infrastructure.Security
{
    /// <summary>
    /// 采用BCrypt密码哈希算法
    /// </summary>
    internal class BCryptPasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// 对密码进行哈希
        /// </summary>
        /// <param name="password">输入的密码</param>
        /// <returns></returns>
        public string Hash(string password)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="password">输入的密码</param>
        /// <param name="passwordHash">经过哈希过的密码</param>
        /// <returns></returns>
        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
