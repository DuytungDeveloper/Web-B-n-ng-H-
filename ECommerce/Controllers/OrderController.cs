using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.Result;
using ECommerce.Middlewares;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext db;
        public static string OrderSessionName = "Order";
        public OrderController(ILogger<ProductController> logger, ApplicationDbContext _db, UserManager<ApplicationUser> _usermana, SignInManager<ApplicationUser> _sign)
        {
            db = _db;
            userManager = _usermana;
            signInManager = _sign;
            _logger = logger;
        }
        [Route("{language}/don-hang/{action=index}")]
        public IActionResult Index()
        {
            OrderViewModel rs = new OrderViewModel() { Products = new List<Product>() };
            SaveOrderViewModel cart = HttpContext.Session.Get<SaveOrderViewModel>(OrderSessionName);
            if (cart != null && cart.AllProduct != null)
            {
                for (int i = 0; i < cart.AllProduct.Count; i++)
                {
                    var item = cart.AllProduct[i];
                    var pro = db.Products.Where(x => x.Id == item.ProductId).Include(x => x.Product_Media).Include("Product_Media.Media").FirstOrDefault();
                    if (pro != null)
                    {
                        pro.Qty = item.Qty;
                        rs.Products.Add(pro);
                    }
                }
            }
            var total = rs.Total;
            return View(rs);
        }

        [HttpPost]
        [Route("{language}/don-hang/{action=SaveOrder}")]
        public IActionResult SaveOrder(SaveOrderViewModel products)
        {
            //HttpContext
            try
            {
                HttpContext.Session.Set(OrderSessionName, products);
                return Json(new ResultData<object>());
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                });
            }
        }
        /// <summary>
        /// Tạo đơn hàng cho khách
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{language}/don-hang/{action=CreateOrder}")]
        public IActionResult CreateOrder(Order orderData)
        {
            //HttpContext
            try
            {
                SaveOrderViewModel allProduct = HttpContext.Session.Get<SaveOrderViewModel>(OrderSessionName);
                orderData.Address.CreateDate = DateTime.Now;
                db.Address.Add(orderData.Address);
                db.SaveChanges();
                orderData.OrderStatusId = 1;
                orderData.Email = string.IsNullOrEmpty(orderData.Email) ? "" : orderData.Email;
                orderData.CustomerName = string.IsNullOrEmpty(orderData.CustomerName) ? "" : orderData.CustomerName;
                orderData.AddressId = orderData.Address.Id;
                orderData.TotalPrice = Helpers.Common.TotalPrice(allProduct.AllProduct.Select(x =>
                {
                    var productDetail = db.Products.Where(y => y.Id == x.ProductId).FirstOrDefault();
                    if (productDetail == null) return new OrderItem();
                    var price = productDetail.PriceDiscount.HasValue && productDetail.DiscountDateTo.HasValue && (DateTime.Now > productDetail.DiscountDateTo.Value) ? productDetail.PriceDiscount.Value : productDetail.Price;
                    var orderItem = new OrderItem()
                    {
                        Quantity = x.Qty,
                        CurrentPrice = price,
                    };
                    return orderItem;
                }).ToList());
                orderData.TotalItemInOrder = Helpers.Common.GetTotalItemInOrder(allProduct.AllProduct.Select(x =>
                {
                    var productDetail = db.Products.Where(y => y.Id == x.ProductId).FirstOrDefault();
                    if (productDetail == null) return new OrderItem();
                    var price = productDetail.PriceDiscount.HasValue && productDetail.DiscountDateTo.HasValue && (DateTime.Now > productDetail.DiscountDateTo.Value) ? productDetail.PriceDiscount.Value : productDetail.Price;
                    var orderItem = new OrderItem()
                    {
                        Quantity = x.Qty,
                        CurrentPrice = price,
                    };
                    return orderItem;
                }).ToList());
                db.Orders.Add(orderData);
                //db.SaveChanges();
                //var orderDataSave = new Order() { 
                //    Code = "",
                //    Note = orderData.Note,
                //    Phone = orderData.Phone,
                //    ReceiverInfo = orderData.ReceiverInfo,
                //    Status = 1,
                //    OrderStatusId = orderData.OrderStatusId,
                //    Email = orderData.Email,
                //    CustomerName = orderData.CustomerName,
                //    AddressId = orderData.AddressId,
                //    CreateDate = DateTime.Now,
                //};
                //db.Orders.Add(orderDataSave);
                db.SaveChanges();
                orderData.OrderItems = new List<OrderItem>();
                for (int i = 0; i < allProduct.AllProduct.Count; i++)
                {
                    var pro = allProduct.AllProduct[i];
                    var productDetail = db.Products.Where(x => x.Id == pro.ProductId).FirstOrDefault();
                    if (productDetail == null) continue;
                    var price = productDetail.PriceDiscount.HasValue && productDetail.DiscountDateTo.HasValue && (DateTime.Now > productDetail.DiscountDateTo.Value) ? productDetail.PriceDiscount.Value : productDetail.Price;
                    var orderItem = new OrderItem()
                    {
                        ProductId = pro.ProductId,
                        Quantity = pro.Qty,
                        CurrentPrice = price,
                        Status = 1,
                        OrderId = orderData.Id,
                        CreateDate = DateTime.Now
                    };
                    db.OrderItems.Add(orderItem);
                    db.SaveChanges();
                    //orderData.OrderItems.Add(orderItem);
                }
                return Json(new ResultData<object>()
                {
                    Success = true,
                    Message = "Lên đơn hàng thành công"
                });
            }
            catch (Exception e)
            {
                return Json(new ResultData<object>()
                {
                    Success = false,
                    ErrorMessage = e.Message
                });
            }
        }
    }
}