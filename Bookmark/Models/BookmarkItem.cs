namespace Bookmark.Models
{
    public class BookmarkItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Url { get; set; }
        public required string Category { get; set; }
        public bool Favorite { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
    }
}