
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.Result;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using ECommerce.Model.EFModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System;
using ECommerce.Model.EFModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ECommerce.Areas.Admin.Controllers
{
    // sản phẩm 
    [Area("Admin")]
    // [Route("Admin/[controller]")]
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
        #region Pages
        [Route("/admin/san-pham")]
        public ActionResult Index()
        {
            return View();
        }

        //[Route("/admin/san-pham/{Id}")]
        //public ActionResult Detail([FromRoute] int Id)
        //{
        //    ViewBag.Id = Id;
        //    return View();
        //}
        #endregion
        #region Action

        //[HttpGet]
        //public async Task<ActionResult<ResultListData<Product>>> GetAll()
        //{
        //    ResultListData<Product> data = new ResultListData<Product>();
        //    var ListProduct = await _ProductService.Product
        //        .Include(o=>o.BrandProduct)
        //        //.Include(o=>o.Chatelaine)
        //        .Include(o=>o.ColorClockFace)
        //        //.Include(o => o.Hem)
        //        //.Include(o => o.HuntingCase)
        //        .Include(o => o.Machine)
        //        //.Include(o => o.Origin)
        //        .Include(o => o.MadeIn)
        //        .ToListAsync();
        //    if (data == null) return data;
        //    data.Data = ListProduct;
        //    data.Success = true;
        //    data.Amount = ListProduct.Count();
        //    data.Message = "Thành công !";
        //    return Ok(data);
        //}

        
        //public async Task<ActionResult<ResultData<Product>>> GetById([FromRoute] int Id)
        //{
        //    ResultData<Product> data = new ResultData<Product>();
        //    Product Item = await _UnitOfWork.Products.GetById(Id);
        //    if (data == null) return data;
        //    data.Data = Item;
        //    data.Success = true;
        //    data.Message = "Thành công !";
        //    return Ok(data);
        //}
        //[HttpPost]
        //public async Task<ActionResult<Product>> Add([FromBody] Product body)
        //{
            
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    ResultData<Product> data = new ResultData<Product>();
        //    body.CreateDate = DateTime.Now;
        //    body.UpdateDate = DateTime.Now;
        //    await _UnitOfWork.Products.Insert(body,true);
        //    await _UnitOfWork.Commit();
        //    data.Data = body;
        //    data.Success = body.Id > 0 ? true :false;
        //    data.Message = body.Id > 0 ?"Thành công !":"Thất bại !";
        //    return Ok(data);
        //}
        //[HttpPut("/admin/san-pham/{Id}")]
        //public async Task<ActionResult<Product>> Update([FromBody] Product body, [FromRoute] int Id=0)
        //{
        //    if (!ModelState.IsValid || Id < 1 )
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var GetItem = await _UnitOfWork.Products.GetById(Id);
        //    ResultData<Product> data = new ResultData<Product>();
        //    if (GetItem == null)
        //     return Ok(data);
        //    #region
        //    GetItem.Characteristics = body.Characteristics;
        //    //GetItem.Code = body.Code;
        //    GetItem.DescriptionFull = body.DescriptionFull;
        //    GetItem.DescriptionShort = body.DescriptionShort;
        //    GetItem.Diameter = body.Diameter;
        //    //GetItem.Function = body.Function;
        //    GetItem.Price = body.Price;
        //    GetItem.PriceDiscount = body.PriceDiscount;
        //    //GetItem.Guarantee = body.Guarantee;
        //    //GetItem.HemId = body.HemId == 0 ? GetItem.HemId : body.HemId;
        //    //GetItem.HuntingCaseId = body.HuntingCaseId == 0 ? GetItem.HuntingCaseId : body.HuntingCaseId;
        //    //GetItem.ChatelaineId = body.ChatelaineId == 0 ? GetItem.ChatelaineId : body.ChatelaineId;
        //    GetItem.ColorClockFaceId = body.ColorClockFaceId == 0 ? GetItem.ColorClockFaceId : body.ColorClockFaceId;
        //    GetItem.MachineId = body.MachineId == 0 ? GetItem.MachineId : body.MachineId;
        //    GetItem.MadeInId = body.MadeInId == 0 ? GetItem.MadeInId : body.MadeInId;
        //    //GetItem.OriginId = body.OriginId == 0 ? GetItem.OriginId : body.OriginId;
        //    GetItem.BrandProductId = body.BrandProductId == 0 ? GetItem.BrandProductId : body.BrandProductId; ;
        //    #endregion
        //    await _UnitOfWork.Products.Update(GetItem, true);
        //    data.Data = body;
        //    data.Success = true;
        //    data.Message = "Thành công !";
        //    return Ok(GetItem);
        //}
        //[HttpDelete("{Id}")]
        //public async Task<ActionResult<ActionResult<Product>>> Delete([FromRoute] int Id = 0)
        //{
        //    if (Id < 1)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    ResultData<Product> data = new ResultData<Product>();
        //    Product GetItem = await _UnitOfWork.Products.GetById(Id);
        //    if (GetItem == null)
        //        return Ok(data);

        //    //GetItem.Status = 1;//delete
        //    await _UnitOfWork.Products.Delete(GetItem, true);
        //    data.Data = GetItem;
        //    data.Success = true;
        //    data.Message = "Thành công !";
          
        //    return Ok(data);
        //}
        #endregion

    }
}