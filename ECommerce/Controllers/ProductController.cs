using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Controllers
{
    [Route("{language}/san-pham/{link?}")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public ProductController(ILogger<ProductController> logger, ApplicationDbContext _db)
        {
            db = _db;
            _logger = logger;
        }
        //[Route("{link?}")]
        //[Route("{language}/san-pham/{link?}")]
        public IActionResult Index(string link)
        {
            Product pro = db.Products.Where(x => x.Url == link).FirstOrDefault();
            if(pro!= null)
            {
                pro.ViewsCount += 1;
                db.Products.Update(pro);
                db.SaveChanges();
            }
            return View();
        }


    }
}