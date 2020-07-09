using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("/admin/trang-chu")]
        public ActionResult Index()
        {
            return View();
        }



    }
}