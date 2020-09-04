using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Areas.Admin.Models;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

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
                List<Ward> rs = db.Wards.ToList();
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
                List<District> rs = db.Districts.ToList();
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
                List<City> rs = db.Citys.ToList();
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
                List<District> rs = db.Districts.Where(x => x.City.Id == id).ToList();
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
        public async Task<ActionResult<ResultData<IEnumerable<Order>>>> GetAllOrder([FromForm]FilterViewModel filter)
        {
            db.Database.SetCommandTimeout(99999999);
            ResultData<IEnumerable<Order>> rs = new ResultData<IEnumerable<Order>>();
            string stringSearch = filter.search.value;
            var mainQuery = db.Orders.Where(orders =>
                            stringSearch.Contains(orders.Id.ToString())
                         || stringSearch.Contains(orders.Code)
                         || stringSearch.Contains(orders.CustomerName)
                         || stringSearch.Contains(orders.Email)
                         || stringSearch.Contains(orders.Phone)
                         || stringSearch.Contains(orders.Note)
                         || stringSearch.Contains(orders.ReceiverInfo)
                         || stringSearch.Contains(orders.CreateDate.ToString())
                         || stringSearch.Contains(orders.Address.Street)
                         || stringSearch.Contains(orders.OrderStatus.Name)


                         || orders.Code.Contains(stringSearch)
                         || orders.CustomerName.Contains(stringSearch)
                         || orders.Email.Contains(stringSearch)
                         || orders.Phone.Contains(stringSearch)
                         || orders.Note.Contains(stringSearch)
                         || orders.ReceiverInfo.Contains(stringSearch)
                         || orders.CreateDate.ToString().Contains(stringSearch)
                         || orders.Address.Street.Contains(stringSearch)
                         || orders.OrderStatus.Name.Contains(stringSearch)


                         ).Include(x => x.Address).Include(x => x.OrderItems).Include(x => x.OrderStatus).AsQueryable();
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
        [Route("api/Order/all")]
        public async Task<ActionResult<ResultData<IEnumerable<Order>>>> GetAllOrder()
        {
            ResultData<IEnumerable<Order>> data = new ResultData<IEnumerable<Order>>();
            var Item = await GetAll<Order>();
            if (Item == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [Route("api/Order")]
        public async Task<ActionResult<ResultData<Order>>> GetOrderById([FromRoute] int Id)
        {
            ResultData<Order> data = new ResultData<Order>();
            Order Item = await GetById<Order>(Id);
            if (Item == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        [Route("api/Order")]
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
        [HttpPut("{Id}")]
        [Route("api/Order")]
        public async Task<ActionResult<ResultData<Order>>> Update([FromBody] Order body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await GetById<Order>(Id);
            ResultData<Order> data = new ResultData<Order>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.OrderStatusId = body.OrderStatusId == 0 ? GetItem.OrderStatusId : body.OrderStatusId;
            GetItem.Note = body.Note;
            GetItem.Phone = body.Phone;
            GetItem.Code = body.Code;
            GetItem.ReceiverInfo = body.ReceiverInfo;
            GetItem.OrderStatusId = body.OrderStatusId == 0 ? GetItem.OrderStatusId : body.OrderStatusId;
            GetItem.UpdateBy = body.UpdateBy;
            GetItem.UpdateDate = DateTime.Now;
            #endregion
            var rs = await Update<Order>(GetItem);
            data.Data = body;
            data.Success = rs > 0 ? true : false;
            data.Message = rs > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpDelete("{Id}")]
        [Route("api/Order")]
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

    }
}