using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
    }
}
