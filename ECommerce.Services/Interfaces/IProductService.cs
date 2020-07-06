using ECommerce.Model.EFModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Interfaces
{
    public interface IProductService<TEntity> where TEntity : class
    {
        DbSet<TEntity> Product { get; }
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Report();
        
    }
}
