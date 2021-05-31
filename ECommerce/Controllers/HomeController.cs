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
            StaticData.SystemInfos = db.SystemInfomation.Where(x => x.Status == 1).ToList();
        }

        public IActionResult Index()
        {
            #region Sản phẩm bán chạy nhất
            List<Product> sanPhamChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (sanPhamChayNhat.Count == 0)
            {
                sanPhamChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 3).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(x => x.Reviews).ToList();
            }
            #endregion

            #region Sản phẩm mới nhất
            List<Product> sanPhamMoiNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.MauMoi).OrderBy(x => x.OrderId).Include(x => x.Product).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (sanPhamMoiNhat.Count == 0)
                sanPhamMoiNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 2).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(x => x.Reviews).ToList();
            #endregion

            #region Sản phẩm có deal hời
            List<Product> sanPhamGiamGia = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DealHoi).OrderBy(x => x.OrderId).Include(x => x.Product).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (sanPhamGiamGia.Count == 0)
                sanPhamGiamGia = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 4).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(x => x.Reviews).ToList();
            #endregion

            Models.View.HomeSliderProductPartial sliderData = new Models.View.HomeSliderProductPartial()
            {
                sanPhamChayNhat = sanPhamChayNhat,
                sanPhamMoiNhat = sanPhamMoiNhat,
                sanPhamGiamGia = sanPhamGiamGia,
            };



            #region đồng hồ nam bán chạy nhất
            List<Product> DongHoNam_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNam_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoNam_BanChayNhat.Count == 0)
            {
                DongHoNam_BanChayNhat = db.Products.Where(x => x.CategoryId == 2 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ nam nhiều người xem
            List<Product> DongHoNam_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNam_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoNam_NhieuNguoiXem.Count == 0)
            {
                DongHoNam_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 2 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ nữ bán chạy nhất
            List<Product> DongHoNu_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNu_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoNu_BanChayNhat.Count == 0)
            {
                DongHoNu_BanChayNhat = db.Products.Where(x => x.CategoryId == 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ nữ nhiều người xem
            List<Product> DongHoNu_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNu_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoNu_NhieuNguoiXem.Count == 0)
            {
                DongHoNu_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ te bán chạy nhất
            List<Product> DongHoTreEm_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoTreEm_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoTreEm_BanChayNhat.Count == 0)
            {
                DongHoTreEm_BanChayNhat = db.Products.Where(x => x.CategoryId == 4 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ te nhiều người xem
            List<Product> DongHoTreEm_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoTreEm_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoTreEm_NhieuNguoiXem.Count == 0)
            {
                DongHoTreEm_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 4 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ ca bán chạy nhất
            List<Product> DongHoCap_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoCap_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoCap_BanChayNhat.Count == 0)
            {
                DongHoCap_BanChayNhat = db.Products.Where(x => x.CategoryId == 3 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ ca nhiều người xem
            List<Product> DongHoCap_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoCap_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoCap_NhieuNguoiXem.Count == 0)
            {
                DongHoCap_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 3 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ db bán chạy nhất
            List<Product> DongHoPhienBanDacBiet_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanDacBiet_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoPhienBanDacBiet_BanChayNhat.Count == 0)
            {
                DongHoPhienBanDacBiet_BanChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 6).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ db nhiều người xem
            List<Product> DongHoPhienBanDacBiet_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanDacBiet_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoPhienBanDacBiet_NhieuNguoiXem.Count == 0)
            {
                DongHoPhienBanDacBiet_NhieuNguoiXem = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 6).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ gh bán chạy nhất
            List<Product> DongHoPhienBanGioiHan_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanGioiHan_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoPhienBanGioiHan_BanChayNhat.Count == 0)
            {
                DongHoPhienBanGioiHan_BanChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 7).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion

            #region đồng hồ gh nhiều người xem
            List<Product> DongHoPhienBanGioiHan_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanGioiHan_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
            if (DongHoPhienBanGioiHan_NhieuNguoiXem.Count == 0)
            {
                DongHoPhienBanGioiHan_NhieuNguoiXem = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 7).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            }
            #endregion



            //List<Product> donghoNam = db.Products.Where(x => x.CategoryId == 2 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            //List<Product> donghoNu = db.Products.Where(x => x.CategoryId == 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            //List<Product> donghoCap = db.Products.Where(x => x.CategoryId == 3 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            //List<Product> donghoTreEm = db.Products.Where(x => x.CategoryId == 4 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            //List<Product> donghoPhienBanDacBiet = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 6).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
            //List<Product> donghoPhienBanGioiHan = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 7).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();

            //List<BrandProduct> allBrand = db.BrandProducts.ToList();
            HomeDataView data = new HomeDataView()
            {
                HomeSliderProductPartial = sliderData,
                DongHoNam_BanChayNhat = DongHoNam_BanChayNhat,
                DongHoNam_NhieuNguoiXem = DongHoNam_NhieuNguoiXem,

                DongHoNu_BanChayNhat = DongHoNu_BanChayNhat,
                DongHoNu_NhieuNguoiXem = DongHoNu_NhieuNguoiXem,

                DongHoTreEm_BanChayNhat = DongHoTreEm_BanChayNhat,
                DongHoTreEm_NhieuNguoiXem = DongHoTreEm_NhieuNguoiXem,

                DongHoPhienBanDacBiet_BanChayNhat = DongHoPhienBanDacBiet_BanChayNhat,
                DongHoPhienBanDacBiet_NhieuNguoiXem = DongHoPhienBanDacBiet_NhieuNguoiXem,

                DongHoPhienBanGioiHan_BanChayNhat = DongHoPhienBanGioiHan_BanChayNhat,
                DongHoPhienBanGioiHan_NhieuNguoiXem = DongHoPhienBanGioiHan_NhieuNguoiXem,

                DongHoCap_BanChayNhat = DongHoCap_BanChayNhat,
                DongHoCap_NhieuNguoiXem = DongHoCap_NhieuNguoiXem,
                //AllBrandProduct = allBrand
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

        public IActionResult FooterPartial()
        {
            List<SystemInfomation> data = db.SystemInfomation.ToList();
            return View("_FooterPartial", data);
        }

    }
}
