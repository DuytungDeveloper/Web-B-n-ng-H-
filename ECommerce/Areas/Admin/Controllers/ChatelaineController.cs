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
    //-- Dây đeo đồng hồ
    [Area("Admin")]
    // [Route("Admin/[controller]")]
    public class ChatelaineController : Controller
    {
        private readonly IUnitOfWork<Chatelaine> _UnitOfWork;
        public ChatelaineController(IUnitOfWork<Chatelaine> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<Chatelaine>>> GetAll()
        {
            ResultListData<Chatelaine> data = new ResultListData<Chatelaine>();
            var ListChatelaine = await _UnitOfWork.Chatelaines.GetAll();
            if (data == null) return data;
            data.Data = ListChatelaine;
            data.Success = true;
            data.Amount = ListChatelaine.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        
        public async Task<ActionResult<ResultData<Chatelaine>>> GetById([FromRoute] int Id)
        {
            ResultData<Chatelaine> data = new ResultData<Chatelaine>();
            Chatelaine Item = await _UnitOfWork.Chatelaines.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Chatelaine>> Add([FromBody] Chatelaine body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Chatelaine> data = new ResultData<Chatelaine>();
            await _UnitOfWork.Chatelaines.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Chatelaine>> Update([FromBody] Chatelaine body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.Chatelaines.GetById(Id);
            ResultData<Chatelaine> data = new ResultData<Chatelaine>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.Chatelaines.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<Chatelaine>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<Chatelaine> data = new ResultData<Chatelaine>();
            Chatelaine GetItem = await _UnitOfWork.Chatelaines.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.Chatelaines.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
