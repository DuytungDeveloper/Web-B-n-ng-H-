using ECommerce.Model.EFModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Interfaces
{
    public interface IProductService
    {
        DbSet<Product> Product { get; }
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> Report();
        
    }
}
