using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Model.Result;
using ECommerce.Models.View;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public ProductController(ILogger<ProductController> logger, ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            db = _db;
            userManager = _usermana;
            signInManager = _sign;
            _logger = logger;
        }
        //[Route("{link?}")]
        //[Route("{language}/san-pham/{link?}")]
        [Route("{language}/san-pham/{link?}")]
        public IActionResult Index(string link)
        {
            try
            {
                List<string> lsData = link.Split(".").ToList();
                if (lsData.Count() != 2)
                {
                    return RedirectToAction("index", "Home");
                }
                string linkUrl = lsData[0];
                int id = int.Parse(lsData[1]);
                Product pro = db.Products.Where(x => x.Url == linkUrl && x.Id == id).Include(x => x.Category).Include(x => x.BrandProduct).Include(x => x.Product_Media).Include("Product_Media.Media").Include(i => i.Product_ProductStatus).Include("Product_ProductStatus.ProductStatus").Include(x => x.Machine).Include(x => x.Band).Include(x => x.Strap).Include(x => x.ColorClockFace).Include(x => x.MadeIn).Include(x => x.Style).Include(x => x.Waterproof).Include(i => i.Reviews).Include("Reviews.ApplicationUser").FirstOrDefault();
                if (pro != null)
                {
                    List<Product> lsSanPhamMoiCungLoai = db.Products.Where(x => x.CategoryId == pro.CategoryId && x.BrandProductId == pro.BrandProductId).OrderByDescending(x => x.CreateDate.Value).Include(x => x.Product_Media).Include("Product_Media.Media").Include(i => i.Product_ProductStatus).Include("Product_ProductStatus.ProductStatus").Include(x => x.Reviews).Take(5).ToList();
                    List<Product> lsSanPhamMoiTuongTu = db.Products.Where(x => x.CategoryId == pro.CategoryId || x.BrandProductId == pro.BrandProductId || x.MachineId == pro.MachineId || x.BandId == pro.BandId || x.MadeInId == pro.MadeInId || x.StyleId == pro.StyleId || x.WaterproofId == pro.WaterproofId).OrderByDescending(x => x.CreateDate.Value).Include(x => x.Product_Media).Include("Product_Media.Media").Include(i => i.Product_ProductStatus).Include("Product_ProductStatus.ProductStatus").Include(x => x.Reviews).Take(5).ToList();
                    List<Product> lsGiamGia = db.Products.Where(x => x.Product_ProductStatus.Where(z => z.ProductStatusId == 4).Count() > 0 && x.PriceDiscount.HasValue && x.DiscountDateFrom.HasValue && x.DiscountDateTo.HasValue).OrderByDescending(x => x.CreateDate.Value).Include(x => x.Product_Media).Include("Product_Media.Media").Include(i => i.Product_ProductStatus).Include("Product_ProductStatus.ProductStatus").Include(x => x.Reviews).Take(5).ToList();
                    if (pro != null)
                    {
                        pro.ViewsCount += 1;
                        db.Products.Update(pro);
                        db.SaveChanges();
                    }
                    List<Category> cat = db.Category.Take(10).ToList();
                    ProductDetailView dataView = new ProductDetailView()
                    {
                        ProductDetail = pro,
                        SanPhamCungLoai = lsSanPhamMoiCungLoai,
                        SanPhamTuongTu = lsSanPhamMoiTuongTu,
                        SanPhamGiamGia = lsGiamGia,
                        DanhMucKhac = cat
                    };
                    ViewData["Title"] = pro.Name;
                    ViewData["Description"] = pro.TitleSEO;
                    return View(dataView);
                }
                else
                {
                    return RedirectToAction("index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("index", "Home");
            }

        }
        [HttpGet]
        [Route("getProduct/{link?}")]
        public IActionResult GetProduct(string link)
        {
            try
            {
                List<string> lsData = link.Split(".").ToList();
                if (lsData.Count() != 2)
                {
                    return Json(new ResultData<object>()
                    {
                        Success = false,
                        ErrorMessage = "Sai dữ liệu đầu vào!",
                        StatusCode = "002"
                    });
                }
                string linkUrl = lsData[0];
                int id = int.Parse(lsData[1]);
                Product pro = db.Products.Where(x => x.Url == linkUrl && x.Id == id).Include(x => x.Category).Include(x => x.Product_Media).Include("Product_Media.Media").Include(i => i.Product_ProductStatus).Include("Product_ProductStatus.ProductStatus").FirstOrDefault();
                if (pro != null)
                {
                    if (pro != null)
                    {
                        pro.ViewsCount += 1;
                        db.Products.Update(pro);
                        db.SaveChanges();
                    }
                    List<Product_Media> medias = new List<Product_Media>();
                    if(pro.Product_Media.Count() > 0)
                    {
                        var media = new Media()
                        {
                            Link = pro.Product_Media[0].Media.Link
                        };
                        medias.Add(new Product_Media()
                        {
                            Media = media
                        });
                    }
                    else
                    {
                        var media = new Media()
                        {
                            Link = "/assets/data/p35.jpg"
                        };
                        medias.Add(new Product_Media()
                        {
                            Media = media
                        });
                    }
                    
                    return Json(new ResultData<Product>()
                    {
                        Data = new Product()
                        {
                            Id = pro.Id,
                            Url = pro.Url,
                            Name = pro.Name,
                            Price = pro.Price,
                            PriceDiscount = pro.PriceDiscount,
                            DiscountDateFrom = pro.DiscountDateFrom,
                            DiscountDateTo = pro.DiscountDateTo,
                            //Product_ProductStatus = pro.Product_ProductStatus,
                            Product_Media = medias,
                        }
                    });
                    // 
                }
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Message = "Không tìm thấy sản phẩm",
                    StatusCode = "004"
                });
            }
            catch(Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    ErrorMessage = e.Message,
                    Message = e.InnerException.ToString(),
                    StatusCode = "003"
                });
            }

        }
        [ActionName("danh-gia-san-pham")]
        [HttpPost]
        public async Task<IActionResult> AddReviewToProduct(ReviewProductViewModel data)
        {
            if (User.Identity.IsAuthenticated)
            {
                string encoded = WebUtility.HtmlEncode(data.Message);
                Review rev = new Review() { 
                    ApplicationUserId = userManager.GetUserId(User),
                    ProductId = data.ProductId,
                    Message = encoded,
                    Point = data.Point,
                    CreateDate = new DateTime()
                };
                db.Reviews.Add(rev);
                db.SaveChanges();
                var uer = await userManager.GetUserAsync(User);
                rev.ApplicationUser = new ApplicationUser()
                {
                    UserName = uer.UserName
                };
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Message = "Thêm thành công review!",
                    StatusCode = "006",
                    Data = rev
                });
            }
            else
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    ErrorMessage = "Sai dữ liệu đầu vào!",
                    StatusCode = "005"
                });
            }
        }
    }
}