using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework.Legacy;
using XiangXunBlog.Models;
using XiangXunBlog.Repositories;
using XiangXunBlog.Services;
namespace TestXiangXunBlog
{
    public class UserServiceTests
    {
        private UserService _userService;
        private Mock<IUserRepository> _mockRepo;
        private Mock<IConfiguration> _mockConfig;
        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IUserRepository>();
            _mockConfig = new Mock<IConfiguration>();
            _userService = new UserService(_mockRepo.Object, _mockConfig.Object);
        }

        [Test]
        public void GetUserByUsernameAsync_Works()
        {
            _mockRepo.Setup(repo => repo.GetUserByUsernameAsync("xiangxun"))
                .ReturnsAsync(new User { Id = "1", UserName = "xiangxun", PasswordHash = "123456" });
            var user = _userService.GetUserByUsernameAsync("xiangxun").Result;
            ClassicAssert.AreEqual("xiangxun", user.UserName);
        }






    }
}