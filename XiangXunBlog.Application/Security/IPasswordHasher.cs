namespace XiangXunBlog.Application.Security
{


    /// <summary>
    /// 哈希加密的接口函数
    /// </summary>
    public interface IPasswordHasher
    {

        string Hash(string password);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password">传入的原始密码</param>
        /// <param name="passwordHash">哈希过后的密码</param>
        /// <returns></returns>
        bool Verify(string password, string passwordHash);



    }
}
