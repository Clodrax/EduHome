using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public FooterViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footerVM = new FooterVM()
            {
                Bio = await _db.Bios.FirstAsync(),
                SocialMedia = await _db.SocialMedias.FirstAsync()

            };
                return View(footerVM);
        }
    }
}
