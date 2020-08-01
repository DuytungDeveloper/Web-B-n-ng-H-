using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/search-result")]
    public class SearchController : Controller
    {
        [HttpGet()]
        public IActionResult Index([FromQuery(Name = "page")] string page ="")
        {
            return View();
        }
    }
}