using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            List<About> abouts = await _db.Abouts.ToListAsync();
            return View(abouts);
        }
    }
}
