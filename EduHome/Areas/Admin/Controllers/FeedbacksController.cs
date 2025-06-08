using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class FeedbacksController : Controller
    {
        private readonly AppDbContext _db;
        public FeedbacksController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            List<Feedback> feedbacks = await _db.Feedbacks.ToListAsync();
            return View(feedbacks);
        }
    }
}
