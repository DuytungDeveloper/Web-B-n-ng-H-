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
    //-- mặt đồng hồ
    [Area("Admin")]
    // [Route("Admin/[controller]")]
    public class ColorClockFaceController : Controller
    {
        private readonly IUnitOfWork<ColorClockFace> _UnitOfWork;
        public ColorClockFaceController(IUnitOfWork<ColorClockFace> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<ColorClockFace>>> GetAll()
        {
            ResultListData<ColorClockFace> data = new ResultListData<ColorClockFace>();
            var ListColorClockFace = await _UnitOfWork.ColorClockFace.GetAll();
            if (data == null) return data;
            data.Data = ListColorClockFace;
            data.Success = true;
            data.Amount = ListColorClockFace.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        
        public async Task<ActionResult<ResultData<ColorClockFace>>> GetById([FromRoute] int Id)
        {
            ResultData<ColorClockFace> data = new ResultData<ColorClockFace>();
            ColorClockFace Item = await _UnitOfWork.ColorClockFace.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<ColorClockFace>> Add([FromBody] ColorClockFace body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<ColorClockFace> data = new ResultData<ColorClockFace>();
            await _UnitOfWork.ColorClockFace.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<ColorClockFace>> Update([FromBody] ColorClockFace body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.ColorClockFace.GetById(Id);
            ResultData<ColorClockFace> data = new ResultData<ColorClockFace>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.ColorClockFace.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<ColorClockFace>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<ColorClockFace> data = new ResultData<ColorClockFace>();
            ColorClockFace GetItem = await _UnitOfWork.ColorClockFace.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.ColorClockFace.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion

    }
}
