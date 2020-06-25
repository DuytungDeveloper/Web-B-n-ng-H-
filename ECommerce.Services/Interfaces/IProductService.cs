
using ECommerce.Model.Result;
using ECommerce.Model.EFModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Interfaces
{
   public interface IProductService
   {
        Task<ResultListData<Product>> Get(int id);
        DbSet<Product> Product { get; }
        Task<ResultData<Product>> Add(Product Item);
        Task<ResultListData<Product>> Add(List<Product> LsI);
        Task<ResultData<Product>> Update(Product Item);
        Task<ResultData<Product>> Delete(Product Item);
    }
}
