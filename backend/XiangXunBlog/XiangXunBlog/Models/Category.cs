namespace XiangXunBlog.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public List<Post> Posts { get; set; }
    }
}
