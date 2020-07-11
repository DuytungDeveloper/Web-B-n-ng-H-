using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.Areas.Admin.Controllers
{
    //-- Niềng -- Niềng bao quanh đồng hồ ( thép,vàng , inox ...)
    [Area("Admin")]
    // [Route("Admin/[controller]")]
    public class HemController : Controller
    {
        private readonly IUnitOfWork<Hem> _UnitOfWork;
        public HemController(IUnitOfWork<Hem> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<Hem>>> GetAll()
        {
            ResultListData<Hem> data = new ResultListData<Hem>();
            var ListHem = await _UnitOfWork.Hems.GetAll();
            if (data == null) return data;
            data.Data = ListHem;
            data.Success = true;
            data.Amount = ListHem.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        
        public async Task<ActionResult<ResultData<Hem>>> GetById([FromRoute] int Id)
        {
            ResultData<Hem> data = new ResultData<Hem>();
            Hem Item = await _UnitOfWork.Hems.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Hem>> Add([FromBody] Hem body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Hem> data = new ResultData<Hem>();
            await _UnitOfWork.Hems.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Hem>> Update([FromBody] Hem body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.Hems.GetById(Id);
            ResultData<Hem> data = new ResultData<Hem>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.Hems.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<Hem>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<Hem> data = new ResultData<Hem>();
            Hem GetItem = await _UnitOfWork.Hems.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.Hems.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion

    }
}
