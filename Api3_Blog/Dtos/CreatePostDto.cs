using System.ComponentModel.DataAnnotations;

namespace Api3_Blog.Dtos
{
    public record CreatePostDto(
        [Required, MaxLength(200)] string Title,
        [Required] string Body);
}
