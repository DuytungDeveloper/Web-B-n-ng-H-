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
    //-- trạng thái đơn hàng
    [Area("Admin")]
    // [Route("Admin/[controller]")]
    public class OrderStatusController : Controller
    {
        private readonly IUnitOfWork<OrderStatus> _UnitOfWork;
        public OrderStatusController(IUnitOfWork<OrderStatus> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<OrderStatus>>> GetAll()
        {
            ResultListData<OrderStatus> data = new ResultListData<OrderStatus>();
            var ListOrderStatus = await _UnitOfWork.OrderStatus.GetAll();
            if (data == null) return data;
            data.Data = ListOrderStatus;
            data.Success = true;
            data.Amount = ListOrderStatus.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        
        public async Task<ActionResult<ResultData<OrderStatus>>> GetById([FromRoute] int Id)
        {
            ResultData<OrderStatus> data = new ResultData<OrderStatus>();
            OrderStatus Item = await _UnitOfWork.OrderStatus.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<OrderStatus>> Add([FromBody] OrderStatus body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<OrderStatus> data = new ResultData<OrderStatus>();
            await _UnitOfWork.OrderStatus.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<OrderStatus>> Update([FromBody] OrderStatus body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.OrderStatus.GetById(Id);
            ResultData<OrderStatus> data = new ResultData<OrderStatus>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.Name = body.Name;
            #endregion
            await _UnitOfWork.OrderStatus.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<OrderStatus>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<OrderStatus> data = new ResultData<OrderStatus>();
            OrderStatus GetItem = await _UnitOfWork.OrderStatus.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.OrderStatus.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
