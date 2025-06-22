using XiangXunBlog.Infrastructure.Security;

namespace XiangXunBlog.Tests.Infrastructure.Security
{



    public class BCryptPasswordHasherTest
    {
        [Fact]
        public void SimplePassword()
        {
            BCryptPasswordHasher bCryptPasswordHasher = new();
            string password = "123456";
            string passwordHash = bCryptPasswordHasher.Hash(password);
            Assert.True(bCryptPasswordHasher.Verify(password, passwordHash));

        }
    }
}
