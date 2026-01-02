using Api3_Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Api3_Blog.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");
            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");
            modelBuilder.Entity<Comment>()
                .Property(c => c.Approved)
                .HasDefaultValue(false);
        }
    }
}
