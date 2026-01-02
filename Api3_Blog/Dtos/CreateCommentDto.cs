using System.ComponentModel.DataAnnotations;

namespace Api3_Blog.Dtos
{
    public record CreateCommentDto
    (
        [Required, MaxLength(100)] string Author,
        [Required, MaxLength(1000)] string Body
     );
}
