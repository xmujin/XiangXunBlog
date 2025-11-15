using XiangXunBlog.Models;

namespace XiangXunBlog.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);

        Task<bool> UserExistsAsync(string username);


        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
