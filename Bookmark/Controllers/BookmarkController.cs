using System.ComponentModel;
using System.Diagnostics;
using Bookmark.Data;
using Bookmark.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Bookmark.Controllers
{
    

    [Route("[controller]")]
    [ApiController]
    public class BookmarkController : Controller 
    {
        private readonly AppDbContext _context;
        

        public BookmarkController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> GetBookmarks()
        {
            var bookmarks = await _context.BookmarkItems.ToListAsync();
            
            return View(bookmarks);
        }


        [HttpPost]
        public async Task<IActionResult> AddBookmark(BookmarkItem bookmark)
        {

            return Ok();
        }


    }
}