namespace XiangXunBlog.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
