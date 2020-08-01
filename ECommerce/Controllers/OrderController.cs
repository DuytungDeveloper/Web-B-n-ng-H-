using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/don-hang/{action=index}")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}