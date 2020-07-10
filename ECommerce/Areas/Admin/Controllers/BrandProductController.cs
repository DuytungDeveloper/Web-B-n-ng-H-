using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class BrandProductController : Controller
    {
        private readonly IUnitOfWork<BrandProduct> _UnitOfWork;
        public BrandProductController(IUnitOfWork<BrandProduct> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<BrandProduct>>> GetAll()
        {
            ResultListData<BrandProduct> data = new ResultListData<BrandProduct>();
            var ListChatelaine = await _UnitOfWork.BrandProducts.GetAll();
            if (data == null) return data;
            data.Data = ListChatelaine;
            data.Success = true;
            data.Amount = ListChatelaine.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResultData<BrandProduct>>> GetById([FromRoute] int Id)
        {
            ResultData<BrandProduct> data = new ResultData<BrandProduct>();
            BrandProduct Item = await _UnitOfWork.BrandProducts.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<BrandProduct>> Add([FromBody] BrandProduct body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<BrandProduct> data = new ResultData<BrandProduct>();
            await _UnitOfWork.BrandProducts.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<BrandProduct>> Update([FromBody] BrandProduct body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.BrandProducts.GetById(Id);
            ResultData<BrandProduct> data = new ResultData<BrandProduct>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.BrandProducts.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<BrandProduct>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<BrandProduct> data = new ResultData<BrandProduct>();
            BrandProduct GetItem = await _UnitOfWork.BrandProducts.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 3;//delete
            await _UnitOfWork.BrandProducts.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
