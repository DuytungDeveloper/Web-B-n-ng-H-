using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce.Controllers
{
    public partial class ProductController : BaseController
    {
        public ProductController(IHostingEnvironment env) : base(env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string urlRewrite = "", int id = 0)
        {
            return View();
        }
        
        [HttpGet]
        [Route("product/listdata")]
        public IActionResult ListData(int p = 0, int index = 0)
        {
            var list = new List<object>();
            list.Add(new { name = "Hoang Phong 1", age = 11 });
            list.Add(new { name = "Hoang Phong 2", age = 12 });
            list.Add(new { name = "Hoang Phong 3", age = 13 });
            list.Add(new { name = "Hoang Phong 4", age = 14 });

            return Json(new { success = true, data = list });
        }
    }
}
