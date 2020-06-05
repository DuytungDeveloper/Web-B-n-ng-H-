using ECommerce.Model.EFModel;
using ECommerce.Model.EFViewModel;
using ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Implements
{
    public class ProductService:IProductService
    {
        private readonly EcommerceContext _context;

        public ProductService(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<Product> Get()
        {
            var query =  (from A in _context.ProductAttribute 
                          join M in _context.ProductAttributeMapping on A.Id equals M.ProductAttributeId
                          join P in _context.Product on M.ProductId equals P.Id
                         select new ProductViewModel
                         {
                            Id = P.Id,
                            ProductCode = P.ProductCode,
                            Url = P.Url,
                            DiscountPrice = P.DiscountPrice,
                            SalePrice = P.SalePrice,
                            Images = P.Images,
                            Videos = P.Videos,
                            Note = P.Note,
                            MetaTags = P.MetaTags,
                            Status = P.Status,
                            Created = P.Created,
                            Name = A.Name,
                            Value = M.Value,
                            Type = M.Type
                         }).ToList();

            Product LstP =  _context.Product.SingleOrDefault();
            return LstP;
        }

    
    }
}
