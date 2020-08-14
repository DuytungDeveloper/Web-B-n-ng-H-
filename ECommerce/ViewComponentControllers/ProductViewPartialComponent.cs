using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.ViewComponentControllers
{
    [ViewComponent(Name = "ProductViewPartial")]
    public class ProductViewPartialComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public ProductViewPartialComponent(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke(int type, Product data)
        {
            ProductComponentViewModel model = new ProductComponentViewModel()
            {
                TypeView= type,
                Product = data
            };
            return View("Default",model);
        }
    }
}
