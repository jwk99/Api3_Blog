using System.ComponentModel.DataAnnotations;

namespace Api3_Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }
        [Required, MaxLength(1000)]
        public string Body { get; set; } = null;
        public DateTime CreatedAt { get; set; }
        public bool Approved { get; set; }
    }
}
