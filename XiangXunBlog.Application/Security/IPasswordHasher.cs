namespace XiangXunBlog.Application.Security
{


    /// <summary>
    /// 哈希加密的接口函数
    /// </summary>
    public interface IPasswordHasher
    {

        string Hash(string password);
        bool Verify(string password, string passwordHash);



    }
}
