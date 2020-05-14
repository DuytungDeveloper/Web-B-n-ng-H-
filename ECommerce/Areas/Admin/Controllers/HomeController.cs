using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly EcommerceContext _context;
        private readonly IProductService _product;
        public HomeController(IProductService product, EcommerceContext context)
        {
            _product = product;
            _context = context;
        }
        // GET: Home
        public  ActionResult Index()
        {
            var data =  _product.Get();
            return View();
        }

       
    }
}