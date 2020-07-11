using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.EFModel.Models;
using ECommerce.Model.Result;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    //Đồng có các dòng máy tự động , không tự dộng ...
    [Area("Admin")]
    // [Route("Admin/[controller]")]
    public class MachineController : Controller
    {

        private readonly IUnitOfWork<Machine> _UnitOfWork;
        public MachineController(IUnitOfWork<Machine> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<Machine>>> GetAll()
        {
            ResultListData<Machine> data = new ResultListData<Machine>();
            var ListMachine = await _UnitOfWork.Machines.GetAll();
            if (data == null) return data;
            data.Data = ListMachine;
            data.Success = true;
            data.Amount = ListMachine.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        
        public async Task<ActionResult<ResultData<Machine>>> GetById([FromRoute] int Id)
        {
            ResultData<Machine> data = new ResultData<Machine>();
            Machine Item = await _UnitOfWork.Machines.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Machine>> Add([FromBody] Machine body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Machine> data = new ResultData<Machine>();
            await _UnitOfWork.Machines.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Machine>> Update([FromBody] Machine body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.Machines.GetById(Id);
            ResultData<Machine> data = new ResultData<Machine>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.Machines.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<Machine>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<Machine> data = new ResultData<Machine>();
            Machine GetItem = await _UnitOfWork.Machines.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.Machines.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
