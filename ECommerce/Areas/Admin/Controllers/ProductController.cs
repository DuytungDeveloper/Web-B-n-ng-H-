using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.Result;
using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// get() truyền 0 là lấy all còn khác 0 là lấy theo id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Product>> Get(int id)
        {
            ResultListData<Product> data = await _product.Get(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Product Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            ResultData <Product> data = await _product.Add(Item);
            return Ok(data);
        }
        [HttpPut]
        public async Task<ActionResult<Product>> Update([FromBody] Product Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var GetItem = await _product.Product.AsNoTracking().Where(x=>x.Id == Item.Id).FirstOrDefaultAsync();
            if(GetItem == null)
                return NotFound("ENTRY_NOT_FOUND");
            ResultData<Product> data = await _product.Update(Item);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<ActionResult<Product>> Delete(Product Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var GetItem = await _product.Product.AsNoTracking().Where(x => x.Id == Item.Id).FirstOrDefaultAsync();
            if (GetItem == null)
                return NotFound("ENTRY_NOT_FOUND");
            ResultData<Product> data = await _product.Delete(Item);
            return Ok(data);
        }


    }
}