using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Services.Implements
{
    public class ProductService:IProductService
    {
        private readonly EcommerceContext _context;

        public ProductService(EcommerceContext context)
        {
            _context = context;
        }
        public Product Get()
        {
            Product LstP =   _context.Product.SingleOrDefault();
            return LstP;
        }
    }
}
