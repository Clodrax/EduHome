using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SocialMediasController : Controller
    {
        private readonly AppDbContext _db;
        public SocialMediasController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            List<SocialMedia> socialMedias = await _db.SocialMedias.ToListAsync();
            return View(socialMedias);
        }
    }
}
