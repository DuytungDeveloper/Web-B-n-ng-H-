using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ECommerce.Models;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ECommerce.Models.View;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            db = _db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<Product> sanPhamChayNhat = db.Products.Include(i => i.Category).Where(x => x.Name != "").Take(3).ToList();
            List<Product> sanPhamChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 3).Count() >= 1 && x.Status == 1).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List<Product> sanPhamMoiNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 2).Count() >= 1 && x.Status == 1).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List<Product> sanPhamGiamGia = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 4).Count() >= 1 && x.Status == 1).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            Models.View.HomeSliderProductPartial sliderData = new Models.View.HomeSliderProductPartial()
            {
                sanPhamChayNhat = sanPhamChayNhat,
                sanPhamMoiNhat = sanPhamMoiNhat,
                sanPhamGiamGia = sanPhamGiamGia,
            };

            List<Product> donghoNam = db.Products.Where(x => x.CategoryId == 2 && x.Status == 1).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List <Product> donghoNu = db.Products.Where(x => x.CategoryId == 1 && x.Status == 1).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List<Product> donghoCap = db.Products.Where(x => x.CategoryId == 3 && x.Status == 1).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List<Product> donghoTreEm = db.Products.Where(x => x.CategoryId == 4 && x.Status == 1).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List<Product> donghoPhienBanDacBiet = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 6).Count() >= 1 && x.Status == 1).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();
            List<Product> donghoPhienBanGioiHan = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 7).Count() >= 1 && x.Status == 1).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").ToList();

            HomeDataView data = new HomeDataView()
            {
                HomeSliderProductPartial = sliderData,
                DongHoNam = donghoNam,
                DongHoNu = donghoNu,
                DongHoCap = donghoCap,
                DongHoTreEm = donghoTreEm,
                DongHoPhienBanDacBiet = donghoPhienBanDacBiet,
                DongHoPhienBanGioiHan = donghoPhienBanGioiHan,

            };




            //Console.WriteLine(sanPhamChayNhat[0].Price.ToString("C0", CultureInfo.CurrentCulture));
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
