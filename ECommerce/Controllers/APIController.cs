using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Areas.Admin.Models;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    [ApiController]
    public class APIController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public APIController(ILogger<ProductController> logger, ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            db = _db;
            userManager = _usermana;
            signInManager = _sign;
            _logger = logger;
        }

        #region Common
        [Authorize]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Developer")]
        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            //ResultListData<TEntity> data = new ResultListData<TEntity>();
            var dbSet = db.Set<TEntity>();
            return dbSet.ToList();
        }
        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : class
        {
            var dbSet = db.Set<TEntity>();
            var result = dbSet.FindAsync(id).Result;
            return result;
        }
        public async Task<int> Add<TEntity>(TEntity data) where TEntity : class
        {
            var dbSet = db.Set<TEntity>();
            dbSet.Add(data);
            var result = db.SaveChanges();
            return result;
        }
        public async Task<int> Update<TEntity>(TEntity data) where TEntity : class
        {
            var dbSet = db.Set<TEntity>();
            dbSet.Update(data);
            var result = db.SaveChanges();
            return result;
        }
        public async Task<int> Delete<TEntity>(TEntity data) where TEntity : class
        {
            var dbSet = db.Set<TEntity>();
            dbSet.Remove(data);
            var result = db.SaveChanges();
            return result;
        }
        public async Task<int> DeleteById<TEntity>(int id) where TEntity : class
        {
            var dbSet = db.Set<TEntity>();
            var getItem = await GetById<TEntity>(id);
            if (getItem == null) return 0;
            dbSet.Remove(getItem);
            var result = db.SaveChanges();
            return result;
        }
        #endregion


        #region Manager Ward
        [Route("api/ward/all")]
        public async Task<IActionResult> GetAllWard()
        {
            try
            {
                List<Ward> rs = db.Wards.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        [Route("api/ward/district")]
        // 
        public async Task<IActionResult> GetDistrictOfWard(int id)
        {
            try
            {
                List<District> rs = db.Districts.Where(x => x.Wards.Where(y => y.Id == id).Count() > 0).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }


        #endregion

        #region Manager District
        [Route("api/district/all")]
        public async Task<IActionResult> GetAllDistrict()
        {
            try
            {
                List<District> rs = db.Districts.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        [Route("api/district/city")]
        // 
        public async Task<IActionResult> GetCityOfDistrict(int id)
        {
            try
            {
                List<City> rs = db.Citys.Where(x => x.Districts.Where(y => y.Id == id).Count() > 0).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }

        [Route("api/district/ward")]
        // 
        public async Task<IActionResult> GetWardOfDistrict(int id)
        {
            try
            {
                List<Ward> rs = db.Wards.Where(x => x.District.Id == id).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }

        #endregion

        #region Manager City
        [Route("api/city/all")]
        public async Task<IActionResult> GetAllCity()
        {
            try
            {
                List<City> rs = db.Citys.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        [Route("api/city/district")]
        public async Task<IActionResult> GetDistrictOfCity(int id)
        {
            try
            {
                List<District> rs = db.Districts.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).Where(x => x.City.Id == id).ToList();
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Data = rs
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    Data = e
                });
            }

        }
        #endregion

        #region Orders
        [HttpPost]
        [Route("api/Order/search")]
        public async Task<ActionResult<ResultData<IEnumerable<Order>>>> GetAllOrder([FromForm] FilterViewModel filter)
        {
            db.Database.SetCommandTimeout(99999999);
            ResultData<IEnumerable<Order>> rs = new ResultData<IEnumerable<Order>>();
            string stringSearch = string.IsNullOrEmpty(filter.search.value) ? "" : filter.search.value;
            //var mainQuery = db.Orders.Where(data =>
            //    (data.Id.ToString()
            //    + " "
            //    + data.Code.ToString()
            //    + " "
            //    + data.CustomerName
            //    + " "
            //    + data.Email
            //    + " "
            //    + data.Phone
            //    + " "
            //    + data.Note
            //    + " "
            //    + data.ReceiverInfo
            //    + " "
            //    + data.CreateDate.Value.ToString()
            //    + " "
            //    + data.Address.Street
            //    + " "
            //    + data.OrderStatus.Name
            //    ).Contains(stringSearch)
            //).Include(x => x.Address).Include(x => x.OrderItems).Include(x => x.OrderStatus).AsEnumerable();
            //var stringSQL = $"select Orders.* from Orders join Address on Orders.AddressId = Address.Id join OrderStatus on Orders.OrderStatusId = OrderStatus.Id where (CAST(Orders.Id as varchar)+ ' '+ Orders.Code+ ' '+ Orders.CustomerName+ ' '+ Orders.Email+ ' '+ Orders.Phone+ ' '+ Orders.Note+ ' '+ Orders.ReceiverInfo+ ' '+ CONVERT(VARCHAR(10),Orders.CreateDate,1) + ' '+ Address.Street+ ' '+ OrderStatus.Name) LIKE N'%{stringSearch.Replace(" ", "%")}%'";
            var stringSQL = $@"
                    select
                        Orders.*
                    from
                        Orders
                        join Address on Orders.AddressId = Address.Id
                        join OrderStatus on Orders.OrderStatusId = OrderStatus.Id
                    where
                        (
                            CAST(Orders.Id as nvarchar) + ' ' + CAST(
                                case
                                    when Orders.Code is not null then (Orders.Code)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CAST(Orders.CustomerName as nvarchar) + ' ' + CAST(
                                case
                                    when Orders.Email is not null then (Orders.Email)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CAST(Orders.Phone as nvarchar) + ' ' + CAST(
                                case
                                    when Orders.Note is not null then (Orders.Note)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CAST(
                                case
                                    when Orders.ReceiverInfo is not null then (Orders.ReceiverInfo)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CONVERT(VARCHAR(10), Orders.CreateDate, 1) + ' ' + Address.Street + ' ' + OrderStatus.Name
                        ) LIKE N'%{stringSearch.Replace(" ", "%")}%'
            ";
            stringSQL = stringSearch == "" ? "select Orders.* from Orders" : stringSQL;
            var mainQuery = db.Orders.FromSqlRaw(stringSQL).Include(x => x.Address).Include(x => x.OrderItems).Include(x => x.OrderStatus).AsEnumerable();
            //int count2 = mainQuery2.Count();
            int count = mainQuery.Count();
            var Item = new List<Order>();
            switch (filter.order[0].column)
            {
                case 0:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Id).Skip(filter.start).Take(filter.length).ToList()
                                                        : mainQuery.OrderBy(x => x.Id).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 1:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.CustomerName).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.CustomerName).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 2:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Phone).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Phone).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 3:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.TotalItemInOrder).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.TotalItemInOrder).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 4:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.TotalPrice).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.TotalPrice).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 5:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 6:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.OrderStatus.Name).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.OrderStatus.Name).Skip(filter.start).Take(filter.length).ToList();
                    break;
                default:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList()
                                                      : mainQuery.OrderBy(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList();
                    break;
            }
            var ItemRS = Item.Select(x => new Order
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                Phone = x.Phone,
                TotalItemInOrder = x.TotalItemInOrder,
                TotalPrice = x.TotalPrice,
                CreateDate = x.CreateDate,
                StatusName = x.OrderStatus.Name,
            }).ToList();
            var result = new FilterResultViewModel<List<Order>>
            {
                draw = filter.draw,
                data = ItemRS,
                recordsTotal = db.Orders.Count(),
                recordsFiltered = count
            };
            return Ok(result);
        }
        [HttpGet("api/Order")]
        public async Task<ActionResult<ResultData<string>>> GetOrderById(int Id)
        {
            ResultData<string> data = new ResultData<string>();
            //Order Item = await GetById<Order>(Id);
            Order Item = db.Orders.Where(x => x.Id == Id).Include(x => x.OrderItems).FirstOrDefault();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost("api/Order")]
        public async Task<ActionResult<ResultData<Order>>> Add([FromBody] Order body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Order> data = new ResultData<Order>();
            var rs = await Add<Order>(body);
            data.Data = body;
            data.Success = rs > 0 ? true : false;
            data.Message = rs > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPost("api/Order/update")]
        public async Task<ActionResult<ResultData<Order>>> Update([FromBody] Order body)
        {
            //if (!ModelState.IsValid || Id < 1)
            if (body.Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await GetById<Order>(body.Id);
            ResultData<Order> data = new ResultData<Order>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.OrderStatusId = body.OrderStatusId == 0 ? GetItem.OrderStatusId : body.OrderStatusId;
            GetItem.Note = string.IsNullOrEmpty(body.Note) ? GetItem.Note : body.Note;
            GetItem.Phone = string.IsNullOrEmpty(body.Phone) ? GetItem.Phone : body.Phone;
            GetItem.Email = string.IsNullOrEmpty(body.Email) ? GetItem.Email : body.Email;
            GetItem.CustomerName = string.IsNullOrEmpty(body.CustomerName) ? GetItem.CustomerName : body.CustomerName;
            GetItem.Code = string.IsNullOrEmpty(body.Code) ? GetItem.Code : body.Code;
            GetItem.ReceiverInfo = string.IsNullOrEmpty(body.ReceiverInfo) ? GetItem.ReceiverInfo : body.ReceiverInfo;
            GetItem.UpdateBy = User.Identity.Name;
            GetItem.UpdateDate = DateTime.Now;
            #endregion
            var rs = await Update<Order>(GetItem);
            data.Data = body;
            data.Success = rs > 0 ? true : false;
            data.Message = rs > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpDelete("api/Order")]
        public async Task<ActionResult<ResultData<Order>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<Order> data = new ResultData<Order>();
            //GetItem.Status = 1;//delete
            var rs = await DeleteById<Order>(Id);
            data.Success = rs > 0 ? true : false;
            data.Message = rs > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        #endregion

        #region Product
        [HttpGet("api/Product/{id}")]
        public async Task<ActionResult<ResultData<string>>> GetProductById(int id)
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



            ResultData<string> data = new ResultData<string>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Products.Where(x => x.Id == id).OrderByDescending(x => x.CreateDate).Take(10).Include(i => i.Product_ProductStatus).Include(i => i.Product_Media).Include("Product_Media.Media").Include(i => i.BrandProduct).Include(x => x.Reviews).FirstOrDefault();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpPost]
        [Route("api/Product/search")]
        public async Task<ActionResult<ResultData<IEnumerable<Order>>>> GetAllProduct([FromForm] FilterViewModel filter)
        {
            db.Database.SetCommandTimeout(99999999);
            ResultData<IEnumerable<Order>> rs = new ResultData<IEnumerable<Order>>();
            string stringSearch = string.IsNullOrEmpty(filter.search.value) ? "" : filter.search.value;
            var mainQuery = db.Products.Where(x => (x.Id.ToString() + x.Name + x.Price.ToString() + (x.PriceDiscount.HasValue ? x.PriceDiscount.ToString() : "") + x.Product_ProductStatus.FirstOrDefault().ProductStatus.Status.ToString()).Contains(stringSearch != null ? stringSearch : "")).Include("Product_Media.Media").Include(x => x.Product_ProductStatus).Include("Product_ProductStatus.ProductStatus").Include(x => x.Reviews).AsQueryable();
            //    .Select(x=> new { 
            //    Id = x.Id,
            //    Anh = x.Product_Media.FirstOrDefault().Media.Link,
            //    Name = x.Name,
            //    Price = x.Price,
            //    PriceDiscount = x.PriceDiscount,
            //    Point = x.Point,
            //    Qty = x.Qty,
            //    Status = x.Product_ProductStatus.FirstOrDefault().ProductStatus.Status
            //}).ToList();
            var stringSQL = $@"
                    select
                        Orders.*
                    from
                        Products pro
                        join Product_ProductStatus status on pro.Status = status.Id
                        left join Product_Media pro_media on pro.Id = pro_media.ProductId
left join Medias media on pro_media.MediaId = media.Id
                    where
                        (
                            CAST(Orders.Id as nvarchar) + ' ' + CAST(
                                case
                                    when Orders.Code is not null then (Orders.Code)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CAST(Orders.CustomerName as nvarchar) + ' ' + CAST(
                                case
                                    when Orders.Email is not null then (Orders.Email)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CAST(Orders.Phone as nvarchar) + ' ' + CAST(
                                case
                                    when Orders.Note is not null then (Orders.Note)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CAST(
                                case
                                    when Orders.ReceiverInfo is not null then (Orders.ReceiverInfo)
                                    else ''
                                end as nvarchar
                            ) + ' ' + CONVERT(VARCHAR(10), Orders.CreateDate, 1) + ' ' + Address.Street + ' ' + OrderStatus.Name
                        ) LIKE N'%{stringSearch.Replace(" ", "%")}%'
            ";
            //var mainQuery = db.Orders.FromSqlRaw(stringSQL).Include(x => x.Address).Include(x => x.OrderItems).Include(x => x.OrderStatus).AsEnumerable();
            //int count2 = mainQuery2.Count();
            int count = mainQuery.Count();
            var Item = new List<Product>();
            switch (filter.order[0].column)
            {
                case 0:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Id).Skip(filter.start).Take(filter.length).ToList()
                                                        : mainQuery.OrderBy(x => x.Id).Skip(filter.start).Take(filter.length).ToList();
                    break;
                //case 1:
                //    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.CustomerName).Skip(filter.start).Take(filter.length).ToList()
                //                                       : mainQuery.OrderBy(x => x.CustomerName).Skip(filter.start).Take(filter.length).ToList();
                //    break;
                case 2:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Name).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Name).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 3:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Price).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Price).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 4:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.PriceDiscount).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.PriceDiscount).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 5:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Reviews.Count).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Reviews.Count).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 6:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Product_ProductStatus.Count).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Product_ProductStatus.Count).Skip(filter.start).Take(filter.length).ToList();
                    break;
                default:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList()
                                                      : mainQuery.OrderBy(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList();
                    break;
            }
            var ItemRS = Item.Select(x =>
            {
                List<string> trangThai = new List<string>() { "Bình thường" };
                if (x.Product_ProductStatus.FirstOrDefault() != null)
                {
                    trangThai = new List<string>();
                    x.Product_ProductStatus.ForEach(x =>
                    {
                        trangThai.Add(x.ProductStatus.Name);
                    });
                }
                return new
                {
                    Id = x.Id,
                    Anh = x.Product_Media.FirstOrDefault() != null ? x.Product_Media.OrderBy(x => x.OrderIndex).FirstOrDefault().Media.Link : "/assets/data/product-s3-850x1036.jpg",
                    Name = x.Name,
                    Price = x.Price,
                    PriceDiscount = x.PriceDiscount,
                    Point = x.Point,
                    Qty = x.Qty,
                    Status = string.Join(",", trangThai)
                };
            }).ToList();
            var result = new FilterResultViewModel<object>
            {
                draw = filter.draw,
                data = ItemRS,
                recordsTotal = db.Products.Count(),
                recordsFiltered = count
            };
            return Ok(result);
        }

        [HttpPost("api/Product")]
        public ActionResult<ResultData<object>> UpdateProduct([FromForm] Product product)
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            bool isNew = false;
            if (Item == null)
            {
                //data.Success = false;
                //data.Message = "Không tìm thấy sản phẩm!";
                //return data;
                Item = new Product();
                isNew = true;
            }
            Item.BandId = product.BandId;
            Item.BrandProductId = product.BrandProductId;
            Item.CategoryId = product.CategoryId;
            Item.Characteristics = product.Characteristics;
            Item.ColorClockFaceId = product.ColorClockFaceId;
            Item.DescriptionFull = product.DescriptionFull;
            Item.DescriptionShort = product.DescriptionShort;
            Item.DescriptionShortSEO = product.DescriptionShortSEO;
            Item.Diameter = product.Diameter;
            Item.DiscountDateFrom = product.DiscountDateFrom;
            Item.DiscountDateTo = product.DiscountDateTo;
            Item.InternationalWarrantyTime = product.InternationalWarrantyTime;
            Item.KeyWordSEO = product.KeyWordSEO;
            Item.MachineId = product.MachineId;
            Item.MadeInId = product.MadeInId;
            Item.Name = product.Name;
            Item.OriginNumber = product.OriginNumber;
            Item.Price = product.Price;
            Item.PriceDiscount = product.PriceDiscount;
            Item.QtyInWareHouse = product.QtyInWareHouse;
            Item.Sku = product.Sku;
            //Item.Status = product.BandId;
            Item.StoreWarrantyTime = product.StoreWarrantyTime;
            Item.StrapId = product.StrapId;
            Item.StyleId = product.StyleId;
            Item.ThicknessOfClass = product.ThicknessOfClass;
            Item.TitleSEO = product.TitleSEO;
            Item.UpdateDate = DateTime.Now;
            Item.Url = product.Url;
            //Item.Video = product.BandId;
            Item.WaterproofId = product.WaterproofId;
            //Item.Product_Media = product.Product_Media;
            if (!isNew)
            {
                var allAnh = db.Product_Media.Where(x => x.ProductId == Item.Id).ToList();
                db.Product_Media.RemoveRange(allAnh);
            }

            //db.SaveChanges();
            int rs = 0;
            if (!isNew)
            {
                rs = db.SaveChanges();
            }
            else
            {
                db.Products.Add(Item);
                rs = db.SaveChanges();
            }
            if (product.Product_Media != null)
                for (int i = 0; i < product.Product_Media.Count; i++)
                {
                    var temp = product.Product_Media[i];
                    db.Product_Media.Add(new Product_Media()
                    {
                        MediaId = temp.MediaId,
                        ProductId = Item.Id,
                        OrderIndex = temp.OrderIndex
                    });
                }
            if (!isNew) db.Product_ProductStatus.RemoveRange(db.Product_ProductStatus.Where(x => x.ProductId == Item.Id).ToList());
            for (int i = 0; i < product.Product_ProductStatus.Count; i++)
            {
                var temp = product.Product_ProductStatus[i];
                db.Product_ProductStatus.Add(new Product_ProductStatus()
                {
                    ProductId = Item.Id,
                    ProductStatusId = temp.ProductStatusId
                });
            }


            db.SaveChanges();

            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = rs > 0 ? true : false;
            data.Message = rs > 0 ? "Thành công !" : "Thất bại!";
            return Ok(data);
        }

        [HttpGet("api/Product/status/all")]
        public async Task<ActionResult<ResultData<string>>> GetProductStatus()
        {

            ResultData<string> data = new ResultData<string>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.ProductStatus.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("api/product/productViewType/{id}")]
        public async Task<ActionResult<ResultData<string>>> GetProductInViewTypeByTypeId(int id)
        {

            ResultData<string> data = new ResultData<string>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == id).OrderBy(x=>x.OrderId).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpPost("api/Product/updateProductInView")]
        public ActionResult<ResultData<object>> UpdateProductInView([FromForm]int viewTypeId, [FromForm] List<ProductsOnFirstPage> products)
        {
            ResultData<object> data = new ResultData<object>();
            if (products.Count <= 0)
            {
                data.Success = false;
                return data;
            }
            var rm = db.ProductsOnFirstPages.Where(x => x.ViewTypeId == viewTypeId).ToList();
            db.ProductsOnFirstPages.RemoveRange(rm);
           var t=  db.SaveChanges();
            for (int i = 0; i < products.Count; i++)
            {
                var dataTmp = new ProductsOnFirstPage()
                {
                    ProductId = products[i].ProductId,
                    ViewTypeId = viewTypeId,
                    OrderId = products[i].OrderId,
                    //Status = 1,
                    //CreateBy = "Admin",
                    //CreateDate = DateTime.Now,
                    //UpdateBy = "Admin",
                    //UpdateDate = DateTime.Now,
                };
                db.ProductsOnFirstPages.Add(dataTmp);
                db.SaveChanges();
            }
            var rs = 1;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Success = rs > 0 ? true : false;
            data.Message = rs > 0 ? "Thành công !" : "Thất bại!";
            return Ok(data);
        }
        #endregion

        #region OrderStatus
        [HttpGet("api/OrderStatus")]
        public async Task<ActionResult<ResultData<string>>> GetAllOrderStatus()
        {
            ResultData<string> data = new ResultData<string>();
            var Item = db.OrderStatus.ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region BrandProduct
        [HttpGet("api/BrandProduct/all")]
        public ActionResult<ResultData<object>> GetAllBrandProduct()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.BrandProducts.Where(x=>x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Machine
        [HttpGet("api/Machine/all")]
        public ActionResult<ResultData<object>> GetAllMachine()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Machines.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Band
        [HttpGet("api/Band/all")]
        public ActionResult<ResultData<object>> GetAllBand()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Bands.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Strap
        [HttpGet("api/Strap/all")]
        public ActionResult<ResultData<object>> GetAllStrap()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Straps.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region ColorClockFace
        [HttpGet("api/ColorClockFace/all")]
        public ActionResult<ResultData<object>> GetAllColorClockFace()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.ColorClockFaces.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region MadeIn
        [HttpGet("api/MadeIn/all")]
        public ActionResult<ResultData<object>> GetAllMadeIn()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.MadeIns.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Style
        [HttpGet("api/Style/all")]
        public ActionResult<ResultData<object>> GetAllStyle()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Styles.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Waterproof
        [HttpGet("api/Waterproof/all")]
        public ActionResult<ResultData<object>> GetAllWaterproof()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Waterproofs.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Category
        [HttpGet("api/Category/all")]
        public ActionResult<ResultData<object>> GetAllCategory()
        {
            ResultData<object> data = new ResultData<object>();
            //Order Item = await GetById<Order>(Id);
            //Product Item = db.Products.Where(x => x.Id == id).Include(x=>x.Product_Media).FirstOrDefault();
            var Item = db.Category.Where(x => x.Status == 1 && !String.IsNullOrEmpty(x.Name)).ToList();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        #endregion

        #region Media
        [HttpGet("api/Media/{id}")]
        public async Task<ActionResult<ResultData<string>>> GetMediaById(int id)
        {
            ResultData<string> data = new ResultData<string>();
            var Item = db.Medias.Where(x => x.Id == id).FirstOrDefault();
            if (Item == null) return data;
            JavaScriptSerializer js = new JavaScriptSerializer();
            data.Data = JsonConvert.SerializeObject(Item, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpPost]
        [Route("api/Media/search")]
        public async Task<ActionResult<ResultData<IEnumerable<Order>>>> GetAllMedia([FromForm] FilterViewModel filter)
        {
            db.Database.SetCommandTimeout(99999999);
            ResultData<IEnumerable<Order>> rs = new ResultData<IEnumerable<Order>>();
            string stringSearch = string.IsNullOrEmpty(filter.search.value) ? "" : filter.search.value;
            var mainQuery = db.Medias.Where(x => (x.Id.ToString() + x.Name + x.Link + x.Path).Contains(stringSearch != null ? stringSearch : "")).Include(x => x.MediaType).AsQueryable();
            int count = mainQuery.Count();
            var Item = new List<Media>();
            switch (filter.order[0].column)
            {
                case 0:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Id).Skip(filter.start).Take(filter.length).ToList()
                                                        : mainQuery.OrderBy(x => x.Id).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 1:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Name).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Name).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 2:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.MediaType.Id).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.MediaType.Id).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 3:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Link).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Link).Skip(filter.start).Take(filter.length).ToList();
                    break;
                case 4:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.Path).Skip(filter.start).Take(filter.length).ToList()
                                                       : mainQuery.OrderBy(x => x.Path).Skip(filter.start).Take(filter.length).ToList();
                    break;
                default:
                    Item = filter.order[0].dir == "desc" ? mainQuery.OrderByDescending(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList()
                                                      : mainQuery.OrderBy(x => x.CreateDate).Skip(filter.start).Take(filter.length).ToList();
                    break;
            }
            var ItemRS = Item.Select(x =>
            {
                return new
                {
                    Id = x.Id,
                    Link = x.Link != null ? x.Link : "/assets/data/product-s3-850x1036.jpg",
                    Name = x.Name,
                    DinhDang = x.MediaType.Name,
                    LinkServer = x.Path,
                    NgayTao = x.CreateDate
                };
            }).ToList();
            //var  ItemRS = Item;
            var result = new FilterResultViewModel<object>
            {
                draw = filter.draw,
                data = ItemRS,
                recordsTotal = db.Medias.Count(),
                recordsFiltered = count
            };
            return Ok(result);
        }
        [HttpPost("api/Media/upload")]
        //public async Task<ActionResult<ResultData<string>>> UploadMedia(List<IFormFile> files)
        public async Task<ActionResult<ResultData<string>>> UploadMedia([FromForm] MediaUploadFile formData)
        {
            ResultData<string> data = new ResultData<string>();
            try
            {
                string filePath = "";
                Media media = new Media();
                media.Name = formData.Name;
                bool isImage = true;
                if (formData.FileUpload != null && formData.FileUpload.Length > 0)
                {
                    if (!string.Equals(formData.FileUpload.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(formData.FileUpload.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(formData.FileUpload.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(formData.FileUpload.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(formData.FileUpload.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(formData.FileUpload.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
                    {
                        isImage = false;
                    }
                    var postedFileExtension = Path.GetExtension(formData.FileUpload.FileName);
                    if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        isImage = false;
                    }
                    //var filePath = Path.GetTempFileName();
                    if (isImage)
                    {
                        media.Path = Environment.CurrentDirectory + "\\wwwroot\\assets\\images\\products\\" + formData.FileUpload.FileName;
                        media.Link = "/assets/images/products/" + formData.FileUpload.FileName;
                        media.MediaTypeId = 1;
                    }
                    else
                    {
                        media.Path = Environment.CurrentDirectory + "\\wwwroot\\assets\\files\\" + formData.FileUpload.FileName;
                        media.Link = "/assets/files/" + formData.FileUpload.FileName;
                        media.MediaTypeId = 2;
                    }


                    using (var stream = System.IO.File.Create(media.Path))
                    {
                        await formData.FileUpload.CopyToAsync(stream);
                    }
                }
                db.Medias.Add(media);
                db.SaveChanges();
                data.Success = true;
                data.Message = "Thành công !";
                return Ok(data);
            }
            catch (Exception e)
            {
                data.Message = e.Message;
                return BadRequest(data);
            }
        }
        #endregion
    }
}