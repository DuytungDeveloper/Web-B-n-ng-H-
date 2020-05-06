using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce.Controllers
{
    public abstract class BaseController : Controller
    {
        private IHostingEnvironment _env;
        protected BaseController(IHostingEnvironment env)
        {
            _env = env;
        }

        #region #-- Redirect page not found --#
        public IActionResult PageNotFound(string statusDescription = "Not found")
        {
            //Response.Clear();
            //Response.StatusCode = 404;
            //Response.StatusDescription = statusDescription;
            //return View("PageNotFound");
            return RedirectToRoutePermanent("RedirectPageNotFound", new { url = Request.PathBase, refr = "" });
        }

        public IActionResult RedirectPageNotFound(string url = "", string refr = "", string statusDescription = "Not found")
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var filePath = System.IO.Path.Combine(webRoot, "test.txt");
                using (var stream = new System.IO.StreamWriter(filePath, true))
                {
                    stream.WriteLine("#### RedirectPageNotFound " + this.Request.Path);
                }
            }
            catch (System.Exception ex)
            {

            }

            Response.Clear();
            Response.StatusCode = 404;
            ViewBag.CurrentPath = url;
            ViewBag.CurrentUrlReferrer = refr;
            return View("PageNotFound");

        }

        #endregion

        protected IActionResult GoHomePage()
        {
            return RedirectToRoute("HomePage");
        }

    }
}
