using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.Result;
using ECommerce.Middlewares;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public OrderController(ILogger<ProductController> logger, ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            db = _db;
            userManager = _usermana;
            signInManager = _sign;
            _logger = logger;
        }
        [Route("{language}/don-hang/{action=index}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("{language}/don-hang/{action=SaveOrder}")]
        public IActionResult SaveOrder(SaveOrderViewModel products)
        {
            //HttpContext
            try
            {
                HttpContext.Session.Set("Order", products);
                return Json(new ResultData<object>());
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                });
            }
        }
    }
}