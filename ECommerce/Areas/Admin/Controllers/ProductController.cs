
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.Result;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using ECommerce.Services.UnitOfWork;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Interfaces;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork<Product> _UnitOfWork;
        private readonly IProductService _ProductService;
        public ProductController(IUnitOfWork<Product> UnitOfWork, IProductService _ProductService)
        {
            _UnitOfWork = UnitOfWork; this._ProductService = _ProductService;
        }
        #region Pages
        [Route("/admin/san-pham")]
        public ActionResult Create()
        {
            return View();
        }
        [Route("/admin/san-pham/{Id}")]
        public ActionResult Detail([FromRoute] int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        #endregion
        #region Action

        [HttpGet]
        public async Task<ActionResult<ResultListData<Product>>> GetAll()
        {
            ResultListData<Product> data = new ResultListData<Product>();
            var ListProduct = await _UnitOfWork.Product.GetAll();
            if (data == null) return data;
            data.Data = ListProduct;
            data.Success = true;
            data.Amount = ListProduct.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResultData<Product>>> GetById([FromRoute] int Id)
        {
            ResultData<Product> data = new ResultData<Product>();
            Product Item = await _UnitOfWork.Product.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product body)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Product> data = new ResultData<Product>();
            await _UnitOfWork.Product.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true :false;
            data.Message = body.Id > 0 ?"Thành công !":"Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Product>> Update([FromBody] Product body, [FromRoute] int Id=0)
        {
            if (!ModelState.IsValid || Id < 1 )
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.Product.GetById(Id);
            ResultData<Product> data = new ResultData<Product>();
            if (GetItem == null)
             return Ok(data);
            #region
            GetItem.Characteristics = body.Characteristics;
            GetItem.Code = body.Code;
            GetItem.DescriptionFull = body.DescriptionFull;
            GetItem.DescriptionShort = body.DescriptionShort;
            GetItem.Diameter = body.Diameter;
            GetItem.Function = body.Function;
            GetItem.Price = body.Price;
            GetItem.PriceDiscount = body.PriceDiscount;
            GetItem.Guarantee = body.Guarantee;
            GetItem.IdHem = body.IdHem == 0 ? GetItem.IdHem : body.IdHem;
            GetItem.IdHuntingCase = body.IdHuntingCase == 0 ? GetItem.IdHuntingCase : body.IdHuntingCase;
            GetItem.IdChatelaine = body.IdChatelaine == 0 ? GetItem.IdChatelaine : body.IdChatelaine;
            GetItem.IdColorClockFace = body.IdColorClockFace == 0 ? GetItem.IdColorClockFace : body.IdColorClockFace;
            GetItem.IdMachine = body.IdMachine == 0 ? GetItem.IdMachine : body.IdMachine;
            GetItem.IdMadeIn = body.IdMadeIn == 0 ? GetItem.IdMadeIn : body.IdMadeIn;
            GetItem.IdOrigin = body.IdOrigin == 0 ? GetItem.IdOrigin : body.IdOrigin;
            GetItem.IdBrandProduct = body.IdBrandProduct == 0 ? GetItem.IdBrandProduct : body.IdBrandProduct; ;
            #endregion
            await _UnitOfWork.Product.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<Product>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<Product> data = new ResultData<Product>();
            Product GetItem = await _UnitOfWork.Product.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.Product.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";
          
            return Ok(data);
        }
        #endregion

    }
}