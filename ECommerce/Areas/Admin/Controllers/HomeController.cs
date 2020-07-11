using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Route("Admin/[controller]")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



    }
}