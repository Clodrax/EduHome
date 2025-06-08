using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _db.Courses.OrderByDescending(x=>x.Id).Take(3).ToListAsync();
            ViewBag.CoursesCount = await _db.Courses.CountAsync();

            return View(courses);
        }
        public async Task<IActionResult> LoadMore(int skip)
        {
            List<Course> courses =await _db.Courses.OrderByDescending(x=>x.Id).Skip(skip).Take(3).ToListAsync();

            return PartialView("_CoursesPartial",courses);
        }
    }
}
