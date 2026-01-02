using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api3_Blog.Data;

namespace Api3_Blog.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class ModerationController : ControllerBase
    {
        private readonly BlogDbContext _db;
        public ModerationController(BlogDbContext db)
        {
            _db = db;
        }
        [HttpGet("pending")]
        public async Task<IActionResult> Pending()
        {
            var pendingPosts=await _db.Comments.Where(c=>!c.Approved).ToListAsync();
            return Ok(pendingPosts);
        }
        [HttpPost("{id:int}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            var comment = await _db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            if (comment.Approved)
            {
                return Conflict();
            }
            comment.Approved = true;
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
