using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BiosController : Controller
    {
        private readonly AppDbContext _db;
        public BiosController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {

            List<Bio> bios = await _db.Bios.ToListAsync();
            return View(bios);
        }
    }
}
