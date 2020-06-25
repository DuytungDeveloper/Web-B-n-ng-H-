using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Common.FormatData;
using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using ECommerce.Services.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly IProductService _product;
        public HomeController(IProductService product)
        {
            _product = product;
        }
        public  async Task<ActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Product>>Add(Product Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Product> data = await _product.Add(Item);
            return Ok(data);
           
        }
        public async Task<ActionResult> Update(Product Item)
        {

            var data = await _product.Update(Item);
            return Json(data);

        }


    }
}