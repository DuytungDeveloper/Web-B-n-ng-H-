using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    //tổng order từng sản phẩm trong hóa đơn
    [Area("Admin")]
    [Route("/admin/order/{action=index}")]
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Developer")]
    public class OrdersController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<ApplicationUser> roleManager;
        private readonly ApplicationDbContext db;

        //public HomeController(UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign, RoleManager<ApplicationUser> _role)
        public OrdersController(ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            userManager = _usermana;
            signInManager = _sign;
            //roleManager = _role;
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
