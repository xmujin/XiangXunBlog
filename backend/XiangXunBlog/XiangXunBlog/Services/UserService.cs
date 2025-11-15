using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using XiangXunBlog.Dtos;
using XiangXunBlog.Models;
using XiangXunBlog.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;



namespace XiangXunBlog.Services
{


    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }


        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _userRepository.GetUserByUsernameAsync(username);
        }


        /// <summary>
        /// 用户的注册
        /// </summary>
        /// <param name="userDto"></param>
        public async Task<bool> RegisterUser(UserDto userDto)
        {
            if (await _userRepository.UserExistsAsync(userDto.Username))
            {
                return false;
            }
            User user = new User
            {
                Id = Ulid.NewUlid().ToString(),
                UserName = userDto.Username,
                PasswordHash = BCryptNet.HashPassword(userDto.Password)
            };
            await _userRepository.CreateUserAsync(user);
            return true;
        }


        public async Task<string?> LoginUser(UserDto userDto)
        {
            User? user = await _userRepository.GetUserByUsernameAsync(userDto.Username);
            if (user == null)
            {
                return null;
            }

            if (!BCryptNet.Verify(userDto.Password, user.PasswordHash))
            {
                return null;
            }
            var issuer = _configuration["JwtConfig:Issuer"];
            var audience = _configuration["JwtConfig:Audience"];
            var key = _configuration["JwtConfig:Key"];
            var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, userDto.Username),

                }),
                Expires = tokenExpiryTimeStamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key!)),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDecriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
    }
}
