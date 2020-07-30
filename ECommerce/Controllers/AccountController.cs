using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("{language}/tai-khoan/{action=index}")]
    //[Route("{language}/tai-khoan")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [ActionName("dang-nhap")]
        public IActionResult SignIn()
        {
            return View("SignIn");
        }
        [ActionName("dang-ky")]
        public IActionResult SignUp()
        {
            return View("SignUp");
        }
    }
}