
using ECommerce.Model.EFModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Interfaces
{
   public interface IProductService
   {
        Task<List<Product>> Get();
   }
}
