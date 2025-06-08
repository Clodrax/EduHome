using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class BlogsController : Controller
    {
        private readonly AppDbContext _db;
        public BlogsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _db.Blogs.ToListAsync();
            return View(blogs);
        }
        
        public async Task<IActionResult> Detail(int id)
        {
            Blog blog = await _db.Blogs.FirstAsync(x => x.Id == id);

            return View(blog);

        }
    }
 
}
