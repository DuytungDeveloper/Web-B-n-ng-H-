using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/san-pham")]
    public class ProductController : Controller
    {
        [Route("{id}")]
        public IActionResult Index(int id)
        {
            return View();
        }


    }
}