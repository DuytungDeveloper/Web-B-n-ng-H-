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
    //order từng sản phẩm 
    public class OrderItemsController : Controller
    {
        private readonly IUnitOfWork<OrderItems> _UnitOfWork;
        public OrderItemsController(IUnitOfWork<OrderItems> UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }


        #region Action
        [HttpGet]
        public async Task<ActionResult<ResultListData<OrderItems>>> GetAll()
        {
            ResultListData<OrderItems> data = new ResultListData<OrderItems>();
            var ListOrderItems = await _UnitOfWork.OrderItems.GetAll();
            if (data == null) return data;
            data.Data = ListOrderItems;
            data.Success = true;
            data.Amount = ListOrderItems.Count();
            data.Message = "Thành công !";
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResultData<OrderItems>>> GetById([FromRoute] int Id)
        {
            ResultData<OrderItems> data = new ResultData<OrderItems>();
            OrderItems Item = await _UnitOfWork.OrderItems.GetById(Id);
            if (data == null) return data;
            data.Data = Item;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<OrderItems>> Add([FromBody] OrderItems body)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<OrderItems> data = new ResultData<OrderItems>();
            await _UnitOfWork.OrderItems.Insert(body);
            await _UnitOfWork.Commit();
            data.Data = body;
            data.Success = body.Id > 0 ? true : false;
            data.Message = body.Id > 0 ? "Thành công !" : "Thất bại !";
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<OrderItems>> Update([FromBody] OrderItems body, [FromRoute] int Id = 0)
        {
            if (!ModelState.IsValid || Id < 1)
            {
                return BadRequest(ModelState);
            }

            var GetItem = await _UnitOfWork.OrderItems.GetById(Id);
            ResultData<OrderItems> data = new ResultData<OrderItems>();
            if (GetItem == null)
                return Ok(data);
            #region
            GetItem.ProductId = body.ProductId;
            GetItem.OrderId = body.OrderId;
            GetItem.Quantity = body.Quantity;
            GetItem.UpdateBy = body.UpdateBy;
            GetItem.UpdateDate = DateTime.Now;
            #endregion
            await _UnitOfWork.OrderItems.Update(GetItem, true);
            data.Data = body;
            data.Success = true;
            data.Message = "Thành công !";
            return Ok(GetItem);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ActionResult<OrderItems>>> Delete([FromRoute] int Id = 0)
        {
            if (Id < 1)
            {
                return BadRequest(ModelState);
            }
            ResultData<OrderItems> data = new ResultData<OrderItems>();
            OrderItems GetItem = await _UnitOfWork.OrderItems.GetById(Id);
            if (GetItem == null)
                return Ok(data);

            GetItem.Status = 1;//delete
            await _UnitOfWork.OrderItems.Delete(GetItem, true);
            data.Data = GetItem;
            data.Success = true;
            data.Message = "Thành công !";

            return Ok(data);
        }
        #endregion
    }
}
