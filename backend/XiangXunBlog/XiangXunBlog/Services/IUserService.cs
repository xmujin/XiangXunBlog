using XiangXunBlog.Dtos;
using XiangXunBlog.Models;

namespace XiangXunBlog.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> RegisterUser(UserDto userDto);
        Task<string?> LoginUser(UserDto userDto);
    }
}
