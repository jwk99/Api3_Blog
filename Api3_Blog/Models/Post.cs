using System.ComponentModel.DataAnnotations;

namespace Api3_Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; } = null;
        [Required]
        public string Body { get; set; } = null;
        public DateTime CreatedAt { get; set; }
    }
}
