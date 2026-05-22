using Microsoft.EntityFrameworkCore;
using Bookmark.Models;

namespace Bookmark.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<BookmarkItem> BookmarkItems { get; set; }
        
    }
}