using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Model.Result;
using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
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

        [HttpPost]
        public async Task<ActionResult<Product>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultListData<Product> data = await _product.Get();
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Add( Product Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ResultData<Product> data = await _product.Add(Item);
            return Ok(data);
        }
        [HttpPut]
        public async Task<ActionResult<Product>> Update(Product Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            ResultData<Product> data = await _product.Delete(Item);
            return Ok(data);
        }


    }
}