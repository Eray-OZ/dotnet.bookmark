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
            var initialBookmarks = await _context.BookmarkItems
                .AsNoTracking()
                .Where(b => b.Category == "general")
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
            
            return View(initialBookmarks);
        }


    [HttpGet]
    public async Task<IActionResult> Fetch(string category)
    {
        var bookmarks = await _context.BookmarkItems
            .AsNoTracking()
            .Where(b => string.IsNullOrEmpty(category) || category == "general" || b.Category == category)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();

        return Ok(bookmarks);
    }




    [HttpGet]
    public async Task<IActionResult> Favorites()
        {
            var favoriteBookmarks = await _context.BookmarkItems
                .AsNoTracking()
                .Where(b => b.Favorite)
                .OrderByDescending(b => b.CreatedAt)
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



    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var bookmark = await _context.BookmarkItems.FindAsync(id);

        if(bookmark == null)
        {
            return NotFound();
        }

        _context.BookmarkItems.Remove(bookmark);
        await _context.SaveChangesAsync();

        return Ok();
    }




}


}