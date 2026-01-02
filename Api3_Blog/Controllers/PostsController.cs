using Api3_Blog.Data;
using Api3_Blog.Dtos;
using Api3_Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api3_Blog.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext _db;
        public PostsController(BlogDbContext db) { _db = db; }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts=await _db.Posts.ToListAsync();
            return Ok(posts);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            var post=new Post { Title=dto.Title, Body=dto.Body};
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPosts), new {id=post.Id}, post);
        }
        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetApprovedComments(int id)
        {
            if(!await _db.Posts.AnyAsync(p=>p.Id==id))
            {
                return NotFound();
            }
            var comments=await _db.Comments
                .Where(c=>c.PostId==id && c.Approved)
                .OrderByDescending(c=>c.CreatedAt)
                .Select(c=>new CommentDto(c.Id, c.Author, c.Body, c.CreatedAt))
                .ToListAsync();
            return Ok(comments);
        }
        [HttpPost("{id:int}/comments")]
        public async Task<IActionResult> AddComment(int id, CreateCommentDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            if(!await _db.Posts.AnyAsync(p=>p.Id == id))
            {
                return NotFound();
            }
            var comment = new Comment
            {
                PostId = id,
                Author = dto.Author,
                Body = dto.Body,
                Approved = false
            };
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return Created($"/api/posts/{id}/comments/{comment.Id}", new {approved = false});
        }
    }
}
