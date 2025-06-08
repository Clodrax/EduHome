using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class AboutViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public AboutViewComponent(AppDbContext db)
        {
            _db = db; 
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AboutVM aboutVM = new AboutVM()
            {
                About = await _db.Abouts.FirstAsync(),
                Feedbacks = await _db.Feedbacks.ToListAsync()
            };
            return View(aboutVM);
        }
    }
}
