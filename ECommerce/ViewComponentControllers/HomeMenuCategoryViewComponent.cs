using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.ViewComponentControllers
{
    public class HomeMenuCategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public HomeMenuCategoryViewComponent(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> lsCate = db.Category.Where(x=>!String.IsNullOrEmpty(x.Name) && x.Status == 1).ToList();
            return View(lsCate);
        }
    }
}
