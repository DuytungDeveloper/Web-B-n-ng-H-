using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Developer")]
    [Authorize]
    [Authorize(Roles = "Admin")]
    //[Authorize(Roles = "Developer")]
    // [Route("Admin/[controller]")]
    public class HomeController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<ApplicationUser> roleManager;
        //public HomeController(UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign, RoleManager<ApplicationUser> _role)
        public HomeController(UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            userManager = _usermana;
            signInManager = _sign;
            //roleManager = _role;
        }

        //public async Task<IActionResult> Index()
        //[Authorize(Roles = "Admin,Developer")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //#region create default user
            //ApplicationUser developer = new ApplicationUser()
            //{
            //    Email = "duytung.developer@gmail.com",
            //    UserName = "duytung"
            //};
            //var resultDeveloper = await userManager.CreateAsync(developer, "123456");
            //if (resultDeveloper.Succeeded)
            //{
            //    var resultRoleDeveloper = await userManager.AddToRoleAsync(developer, "Devleloper");
            //}

            //ApplicationUser adminTrong = new ApplicationUser()
            //{
            //    Email = "vantrong@gmail.com",
            //    UserName = "vantrong"
            //};
            //var resultadminTrong = await userManager.CreateAsync(adminTrong, "123456");
            //if (resultadminTrong.Succeeded)
            //{
            //    var resultRoleDeveloper = await userManager.AddToRoleAsync(adminTrong, "Admin");
            //}

            //ApplicationUser adminThien = new ApplicationUser()
            //{
            //    Email = "thien@gmail.com",
            //    UserName = "thien"
            //};
            //var resultadminThien = await userManager.CreateAsync(adminThien, "123456");
            //if (resultadminThien.Succeeded)
            //{
            //    var resultRoleDeveloper = await userManager.AddToRoleAsync(adminThien, "Admin");
            //}
            //#endregion
            return RedirectToAction("Index", "Orders");
            //return View();
        }



    }
}