using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/lien-he")]
    [Route("{language}/{controller}/{action}")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}