using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            AboutVM aboutVM = new AboutVM
            {
                About = _db.Abouts.First(),
                Feedbacks = _db.Feedbacks.ToList()
            };
            return View(aboutVM);
        }
    }
}
