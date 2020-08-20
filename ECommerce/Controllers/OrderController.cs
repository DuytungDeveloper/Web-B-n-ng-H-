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
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public static string OrderSessionName = "Order";
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
            OrderViewModel rs = new OrderViewModel() { Products = new List<Product>()};
            SaveOrderViewModel cart = HttpContext.Session.Get<SaveOrderViewModel>(OrderSessionName);
            if (cart != null)
            {
                for (int i = 0; i < cart.AllProduct.Count; i++)
                {
                    var item = cart.AllProduct[i];
                    var pro = db.Products.Where(x => x.Id == item.ProductId).Include(x => x.Product_Media).Include("Product_Media.Media").FirstOrDefault();
                    if(pro != null)
                    {
                        pro.Qty = item.Qty;
                        rs.Products.Add(pro);
                    }
                }
            }
            var total = rs.Total;
            return View(rs);
        }

        [HttpPost]
        [Route("{language}/don-hang/{action=SaveOrder}")]
        public IActionResult SaveOrder(SaveOrderViewModel products)
        {
            //HttpContext
            try
            {
                HttpContext.Session.Set(OrderSessionName, products);
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