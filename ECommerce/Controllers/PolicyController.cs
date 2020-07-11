using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/chinh-sach")]
    [Route("{language}/{controller}/{action}")]
    public class PolicyController : Controller
    {
        //[Route("{language}/chinh-sach")]
        public IActionResult Index()
        {
            return View();
        }
    }
}