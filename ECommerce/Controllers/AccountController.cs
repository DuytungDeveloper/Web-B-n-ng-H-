using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    //[Route("{language}/tai-khoan")]
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<ApplicationUser> roleManager;
        //public AccountController(UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign, RoleManager<ApplicationUser> _role)
        public AccountController(UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            userManager = _usermana;
            signInManager = _sign;
            //roleManager = _role;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/tai-khoan/dang-nhap")]
        [Route("{language}/tai-khoan/dang-nhap")]
        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        [HttpPost]
        [Route("{language}/tai-khoan/dang-nhap")]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            var rs = await signInManager.PasswordSignInAsync(data.UserName, data.Password, true, false);
            if (rs.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            return View("SignIn");
        }


        [Route("{language}/tai-khoan/dang-ky")]
        public IActionResult SignUp()
        {
            return View("SignUp", new RegisterViewModel());
        }
        [Route("{language}/tai-khoan/dang-ky")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp", data);
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = data.Email,
                UserName = data.UserName
            };
            var result = await userManager.CreateAsync(user, data.Password);
            var resultRole = await userManager.AddToRoleAsync(user, "Guest");
            if (result.Succeeded)
            {
                return RedirectToAction("dang-nhap");
            }
            return View("SignUp");
        }
        [Route("{language}/tai-khoan/dang-xuat")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [Route("/tai-khoan/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}