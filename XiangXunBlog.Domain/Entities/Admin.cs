using System.ComponentModel.DataAnnotations;

namespace XiangXunBlog.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }


        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;


    }
}
