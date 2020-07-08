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
    public class HuntingCaseController : Controller
    {
        private readonly IUnitOfWork<HuntingCase> _UnitOfWork;
        public HuntingCaseController(IUnitOfWork<HuntingCase> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<HuntingCase>>> GetAll()
        {
            ResultListData<HuntingCase> data = new ResultListData<HuntingCase>();
            var ListHuntingCase = await _UnitOfWork.HuntingCase.GetAll();
            if (data == null) return data;
            data.Data = ListHuntingCase;
            data.Success = true;
            data.Amount = ListHuntingCase.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResultData<HuntingCase>>> GetById([FromRoute] int Id)
        {
            ResultData<HuntingCase> data = new ResultData<HuntingCase>();
            HuntingCase Item = await _UnitOfWork.HuntingCase.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<HuntingCase>> Add([FromBody] HuntingCase body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<HuntingCase> data = new ResultData<HuntingCase>();
            await _UnitOfWork.HuntingCase.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<HuntingCase>> Update([FromBody] HuntingCase body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.HuntingCase.GetById(Id);
            ResultData<HuntingCase> data = new ResultData<HuntingCase>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.HuntingCase.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<HuntingCase>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<HuntingCase> data = new ResultData<HuntingCase>();
            HuntingCase GetItem = await _UnitOfWork.HuntingCase.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.HuntingCase.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion

    }
}
