using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]


    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int currentPage=1)
        {
            int take = 3;
            ViewBag.PageCount =Math.
                Ceiling((decimal)(await _db.Courses.CountAsync())/take);

            List<Course> courses = await _db.Courses.
                OrderByDescending(x=>x.Id).
                Skip((currentPage-1)*take).
                Take(take).ToListAsync();
            ViewBag.CurrentPage = currentPage;

            return View(courses);
        }
    }
}
