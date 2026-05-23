using System.ComponentModel;
using System.Diagnostics;
using Bookmark.Data;
using Bookmark.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Bookmark.Controllers
{
    

    public class BookmarkController : Controller
{
    private readonly AppDbContext _context;

    public BookmarkController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var bookmarks = await _context.BookmarkItems
        .OrderByDescending(b => b.CreatedAt)
        .ToListAsync();
        return View(bookmarks);
    }




    [HttpGet]
    public async Task<IActionResult> Favorites()
        {
            var favoriteBookmarks = await _context.BookmarkItems
            .Where(b => b.Favorite)
            .ToListAsync();

            return View(favoriteBookmarks);
        }




    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(BookmarkItem bookmark)
    {
        bookmark.CreatedAt = DateTime.UtcNow;
        _context.BookmarkItems.Add(bookmark);
        await _context.SaveChangesAsync();

        return RedirectToAction("List");
    }
}


}