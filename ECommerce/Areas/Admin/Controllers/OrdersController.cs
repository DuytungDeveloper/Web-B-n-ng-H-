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
    //tổng order từng sản phẩm trong hóa đơn 
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork<Orders> _UnitOfWork;
        public OrdersController(IUnitOfWork<Orders> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }


        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<Orders>>> GetAll()
        {
            ResultListData<Orders> data = new ResultListData<Orders>();
            var ListOrders = await _UnitOfWork.Orders.GetAll();
            if (data == null) return data;
            data.Data = ListOrders;
            data.Success = true;
            data.Amount = ListOrders.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResultData<Orders>>> GetById([FromRoute] int Id)
        {
            ResultData<Orders> data = new ResultData<Orders>();
            Orders Item = await _UnitOfWork.Orders.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Orders>> Add([FromBody] Orders body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Orders> data = new ResultData<Orders>();
            await _UnitOfWork.Orders.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Orders>> Update([FromBody] Orders body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.Orders.GetById(Id);
            ResultData<Orders> data = new ResultData<Orders>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.IdOrderStatus = body.IdOrderStatus == 0? GetItem.IdOrderStatus: body.IdOrderStatus;
            GetItem.Note = body.Note;
            GetItem.Phone = body.Phone;
            GetItem.Code = body.Code;
            GetItem.ReceiverInfo = body.ReceiverInfo;
            GetItem.Status = body.Status == 0 ? GetItem.Status : body.Status;
            GetItem.Status = body.CustomerId == 0 ? GetItem.CustomerId :body.Status;
            GetItem.UpdateBy = body.UpdateBy;
            GetItem.UpdateDate = DateTime.Now;
            #endregion
            await _UnitOfWork.Orders.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<Orders>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<Orders> data = new ResultData<Orders>();
            Orders GetItem = await _UnitOfWork.Orders.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.Orders.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
