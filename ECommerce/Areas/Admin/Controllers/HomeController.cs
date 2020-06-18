using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly IProductService _product;
        public HomeController(IProductService product)
        {
            _product = product;
        }
        public  async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Get()
        {
            var data = await _product.Get();
            return Json(data);
           
        }

    }
}