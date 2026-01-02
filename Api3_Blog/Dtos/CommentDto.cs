namespace Api3_Blog.Dtos
{
    public record CommentDto
    (
      int Id,
      string Author,
      string Body,
      DateTime CreatedAt
    );
}
