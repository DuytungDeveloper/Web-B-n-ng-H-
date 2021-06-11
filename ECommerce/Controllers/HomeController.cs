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
using Microsoft.Extensions.Caching.Memory;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private IMemoryCache _cache;
        private TimeSpan timeProductFirstPageCache = TimeSpan.FromMinutes(60);

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db, IMemoryCache memoryCache)
        {
            db = _db;
            _logger = logger;
            StaticData.SystemInfos = db.SystemInfomation.Where(x => x.Status == 1).ToList();
            _cache = memoryCache;
        }

        public IActionResult Index()
        {

            #region Sản phẩm bán chạy nhất
            List<Product> sanPhamChayNhat = null;
            sanPhamChayNhat = _cache.Get<List<Product>>("sanPhamChayNhat");
            if (sanPhamChayNhat == null)
            {
                sanPhamChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("sanPhamChayNhat", sanPhamChayNhat, timeProductFirstPageCache);
            }
            if (sanPhamChayNhat.Count == 0)
            {
                sanPhamChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 3).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(x => x.Reviews).ToList();
            }

            #endregion

            #region Sản phẩm mới nhất
            List<Product> sanPhamMoiNhat = null;
            sanPhamMoiNhat = _cache.Get<List<Product>>("sanPhamMoiNhat");
            if (sanPhamMoiNhat == null)
            {
                sanPhamMoiNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.MauMoi).OrderBy(x => x.OrderId).Include(x => x.Product).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("sanPhamMoiNhat", sanPhamMoiNhat, timeProductFirstPageCache);

            }
            if (sanPhamMoiNhat.Count == 0)
            {
                sanPhamMoiNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 2).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("sanPhamMoiNhat", sanPhamMoiNhat, timeProductFirstPageCache);
            }
            #endregion

            #region Sản phẩm có deal hời
            List<Product> sanPhamGiamGia = null;
            sanPhamGiamGia = _cache.Get<List<Product>>("sanPhamGiamGia");
            if (sanPhamGiamGia == null)
            {
                sanPhamGiamGia = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DealHoi).OrderBy(x => x.OrderId).Include(x => x.Product).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("sanPhamGiamGia", sanPhamGiamGia, TimeSpan.FromMinutes(15));
            }

            if (sanPhamGiamGia.Count == 0)
            {
                sanPhamGiamGia = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 4).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(5).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("sanPhamGiamGia", sanPhamGiamGia, TimeSpan.FromMinutes(15));
            }
            #endregion

            Models.View.HomeSliderProductPartial sliderData = new Models.View.HomeSliderProductPartial()
            {
                sanPhamChayNhat = sanPhamChayNhat,
                sanPhamMoiNhat = sanPhamMoiNhat,
                sanPhamGiamGia = sanPhamGiamGia,
            };



            #region đồng hồ nam bán chạy nhất
            List<Product> DongHoNam_BanChayNhat = null;
            DongHoNam_BanChayNhat = _cache.Get<List<Product>>("DongHoNam_BanChayNhat");
            if (DongHoNam_BanChayNhat == null)
            {
                DongHoNam_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNam_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoNam_BanChayNhat", DongHoNam_BanChayNhat, timeProductFirstPageCache);
            }

            if (DongHoNam_BanChayNhat.Count == 0)
            {
                DongHoNam_BanChayNhat = db.Products.Where(x => x.CategoryId == 2 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoNam_BanChayNhat", DongHoNam_BanChayNhat, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ nam nhiều người xem
            List<Product> DongHoNam_NhieuNguoiXem = null;
            DongHoNam_NhieuNguoiXem = _cache.Get<List<Product>>("DongHoNam_NhieuNguoiXem");
            if (DongHoNam_NhieuNguoiXem == null)
            {
                DongHoNam_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNam_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoNam_NhieuNguoiXem", DongHoNam_NhieuNguoiXem, timeProductFirstPageCache);
            }

            if (DongHoNam_NhieuNguoiXem.Count == 0)
            {
                DongHoNam_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 2 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoNam_NhieuNguoiXem", DongHoNam_NhieuNguoiXem, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ nữ bán chạy nhất
            List<Product> DongHoNu_BanChayNhat = null;
            DongHoNu_BanChayNhat = _cache.Get<List<Product>>("DongHoNu_BanChayNhat");
            if (DongHoNu_BanChayNhat == null)
            {
                DongHoNu_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNu_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoNu_BanChayNhat", DongHoNu_BanChayNhat, timeProductFirstPageCache);
            }
            if (DongHoNu_BanChayNhat.Count == 0)
            {
                DongHoNu_BanChayNhat = db.Products.Where(x => x.CategoryId == 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoNu_BanChayNhat", DongHoNu_BanChayNhat, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ nữ nhiều người xem
            List<Product> DongHoNu_NhieuNguoiXem = null;
            DongHoNu_NhieuNguoiXem = _cache.Get<List<Product>>("DongHoNu_NhieuNguoiXem");
            if (DongHoNu_NhieuNguoiXem == null)
            {
                DongHoNu_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoNu_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoNu_NhieuNguoiXem", DongHoNu_NhieuNguoiXem, timeProductFirstPageCache);
            }
            if (DongHoNu_NhieuNguoiXem.Count == 0)
            {
                DongHoNu_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoNu_NhieuNguoiXem", DongHoNu_NhieuNguoiXem, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ te bán chạy nhất
            List<Product> DongHoTreEm_BanChayNhat = null;
            DongHoTreEm_BanChayNhat = _cache.Get<List<Product>>("DongHoTreEm_BanChayNhat");
            if (DongHoTreEm_BanChayNhat == null)
            {
                DongHoTreEm_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoTreEm_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoTreEm_BanChayNhat", DongHoTreEm_BanChayNhat, timeProductFirstPageCache);
            }

            if (DongHoTreEm_BanChayNhat.Count == 0)
            {
                DongHoTreEm_BanChayNhat = db.Products.Where(x => x.CategoryId == 4 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoTreEm_BanChayNhat", DongHoTreEm_BanChayNhat, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ te nhiều người xem
            List<Product> DongHoTreEm_NhieuNguoiXem = null;
            DongHoTreEm_NhieuNguoiXem = _cache.Get<List<Product>>("DongHoTreEm_NhieuNguoiXem");
            if (DongHoTreEm_NhieuNguoiXem == null)
            {
                DongHoTreEm_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoTreEm_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoTreEm_NhieuNguoiXem", DongHoTreEm_NhieuNguoiXem, timeProductFirstPageCache);

            }
            if (DongHoTreEm_NhieuNguoiXem.Count == 0)
            {
                DongHoTreEm_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 4 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoTreEm_NhieuNguoiXem", DongHoTreEm_NhieuNguoiXem, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ ca bán chạy nhất
            List<Product> DongHoCap_BanChayNhat = null;
            DongHoCap_BanChayNhat = _cache.Get<List<Product>>("DongHoCap_BanChayNhat");
            if (DongHoCap_BanChayNhat == null)
            {
                DongHoCap_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoCap_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoCap_BanChayNhat", DongHoCap_BanChayNhat, timeProductFirstPageCache);
            }
            if (DongHoCap_BanChayNhat.Count == 0)
            {
                DongHoCap_BanChayNhat = db.Products.Where(x => x.CategoryId == 3 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoCap_BanChayNhat", DongHoCap_BanChayNhat, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ ca nhiều người xem
            List<Product> DongHoCap_NhieuNguoiXem = null;
            DongHoCap_NhieuNguoiXem = _cache.Get<List<Product>>("DongHoCap_NhieuNguoiXem");
            if (DongHoCap_NhieuNguoiXem == null)
            {
                DongHoCap_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoCap_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoCap_NhieuNguoiXem", DongHoCap_NhieuNguoiXem, timeProductFirstPageCache);
            }

            if (DongHoCap_NhieuNguoiXem.Count == 0)
            {
                DongHoCap_NhieuNguoiXem = db.Products.Where(x => x.CategoryId == 3 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoCap_NhieuNguoiXem", DongHoCap_NhieuNguoiXem, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ db bán chạy nhất
            List<Product> DongHoPhienBanDacBiet_BanChayNhat = null;
            DongHoPhienBanDacBiet_BanChayNhat = _cache.Get<List<Product>>("DongHoPhienBanDacBiet_BanChayNhat");
            if (DongHoPhienBanDacBiet_BanChayNhat == null)
            {
                DongHoPhienBanDacBiet_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanDacBiet_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanDacBiet_BanChayNhat", DongHoPhienBanDacBiet_BanChayNhat, timeProductFirstPageCache);

            }
            if (DongHoPhienBanDacBiet_BanChayNhat.Count == 0)
            {
                DongHoPhienBanDacBiet_BanChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 6).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanDacBiet_BanChayNhat", DongHoPhienBanDacBiet_BanChayNhat, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ db nhiều người xem
            List<Product> DongHoPhienBanDacBiet_NhieuNguoiXem = null;
            DongHoPhienBanDacBiet_NhieuNguoiXem = _cache.Get<List<Product>>("DongHoPhienBanDacBiet_NhieuNguoiXem");
            if (DongHoPhienBanDacBiet_NhieuNguoiXem == null)
            {
                DongHoPhienBanDacBiet_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanDacBiet_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanDacBiet_NhieuNguoiXem", DongHoPhienBanDacBiet_NhieuNguoiXem, timeProductFirstPageCache);

            }

            if (DongHoPhienBanDacBiet_NhieuNguoiXem.Count == 0)
            {
                DongHoPhienBanDacBiet_NhieuNguoiXem = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 6).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanDacBiet_NhieuNguoiXem", DongHoPhienBanDacBiet_NhieuNguoiXem, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ gh bán chạy nhất
            List<Product> DongHoPhienBanGioiHan_BanChayNhat = null;
            DongHoPhienBanGioiHan_BanChayNhat = _cache.Get<List<Product>>("DongHoPhienBanGioiHan_BanChayNhat");
            if (DongHoPhienBanGioiHan_BanChayNhat == null)
            {
                DongHoPhienBanGioiHan_BanChayNhat = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanGioiHan_BanChayNhat).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanGioiHan_BanChayNhat", DongHoPhienBanGioiHan_BanChayNhat, timeProductFirstPageCache);
            }
            if (DongHoPhienBanGioiHan_BanChayNhat.Count == 0)
            {
                DongHoPhienBanGioiHan_BanChayNhat = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 7).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanGioiHan_BanChayNhat", DongHoPhienBanGioiHan_BanChayNhat, timeProductFirstPageCache);
            }
            #endregion

            #region đồng hồ gh nhiều người xem
            List<Product> DongHoPhienBanGioiHan_NhieuNguoiXem = null;
            DongHoPhienBanGioiHan_NhieuNguoiXem = _cache.Get<List<Product>>("DongHoPhienBanGioiHan_NhieuNguoiXem");
            if (DongHoPhienBanGioiHan_NhieuNguoiXem == null)
            {
                DongHoPhienBanGioiHan_NhieuNguoiXem = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == (int)ECommerce.Helpers.Common.SanPhamTrangDauViewType.DongHoPhienBanGioiHan_NhieuNguoiXem).OrderBy(x => x.OrderId).Include(i => i.Product.Product_ProductStatus).Include(i => i.Product.Product_Media).Include("Product.Product_Media.Media").Include(x => x.Product.Reviews).Select(x => x.Product).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanGioiHan_NhieuNguoiXem", DongHoPhienBanGioiHan_NhieuNguoiXem, timeProductFirstPageCache);
            }
            if (DongHoPhienBanGioiHan_NhieuNguoiXem.Count == 0)
            {
                DongHoPhienBanGioiHan_NhieuNguoiXem = db.Products.Where(x => x.Product_ProductStatus.Where(v => v.ProductStatusId == 7).Count() >= 1 && x.Status == 1).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).ToList();
                _cache.Set<List<Product>>("DongHoPhienBanGioiHan_NhieuNguoiXem", DongHoPhienBanGioiHan_NhieuNguoiXem, timeProductFirstPageCache);
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
