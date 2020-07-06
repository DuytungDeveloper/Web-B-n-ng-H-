using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Interfaces;
using ECommerce.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Implements
{
    public class ProductService<TEntity> : BaseRepository<TEntity> ,IProductService<TEntity> where TEntity : class
    {
        public readonly ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;
        public ProductService(ApplicationDbContext _context):base(_context)
        {
            this.context = _context;
            this.dbSet = this.context.Set<TEntity>();

        }
        public DbSet<TEntity> Product
        {
            get
            {
                return this.dbSet;
            }
        }
        // ham đè lại phương thức cha từ BaseRepository 
        public override async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> data = await this.dbSet.ToListAsync();
            return data;
        }
        public async Task<IEnumerable<TEntity>> Report()
        {
            IEnumerable<TEntity> data = await this.dbSet.ToListAsync();
            return data;
        }
    }
}
