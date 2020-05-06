using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce.Controllers
{
    public partial class CategoryController : BaseController
    {
        public CategoryController(IHostingEnvironment env) : base(env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
