using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/san-pham/{link?}")]
    public class ProductController : Controller
    {
        //[Route("{link?}")]
        //[Route("{language}/san-pham/{link?}")]
        public IActionResult Index(string link)
        {
            return View();
        }


    }
}