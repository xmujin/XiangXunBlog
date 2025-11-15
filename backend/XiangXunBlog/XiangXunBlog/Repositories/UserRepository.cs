using Microsoft.EntityFrameworkCore;
using XiangXunBlog.Data;
using XiangXunBlog.Models;

namespace XiangXunBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }


        public Task<bool> UserExistsAsync(string username)
        {
            return _context.Users.AnyAsync(u => u.UserName == username);
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }


    }
}
