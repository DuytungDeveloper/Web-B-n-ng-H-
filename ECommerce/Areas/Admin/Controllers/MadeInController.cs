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
    public class MadeInController : Controller
    {
        private readonly IUnitOfWork<MadeIn> _UnitOfWork;
        public MadeInController(IUnitOfWork<MadeIn> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<MadeIn>>> GetAll()
        {
            ResultListData<MadeIn> data = new ResultListData<MadeIn>();
            var ListMadeIn = await _UnitOfWork.MadeIn.GetAll();
            if (data == null) return data;
            data.Data = ListMadeIn;
            data.Success = true;
            data.Amount = ListMadeIn.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResultData<MadeIn>>> GetById([FromRoute] int Id)
        {
            ResultData<MadeIn> data = new ResultData<MadeIn>();
            MadeIn Item = await _UnitOfWork.MadeIn.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<MadeIn>> Add([FromBody] MadeIn body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<MadeIn> data = new ResultData<MadeIn>();
            await _UnitOfWork.MadeIn.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<MadeIn>> Update([FromBody] MadeIn body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.MadeIn.GetById(Id);
            ResultData<MadeIn> data = new ResultData<MadeIn>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.MadeIn.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<MadeIn>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<MadeIn> data = new ResultData<MadeIn>();
            MadeIn GetItem = await _UnitOfWork.MadeIn.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.MadeIn.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
