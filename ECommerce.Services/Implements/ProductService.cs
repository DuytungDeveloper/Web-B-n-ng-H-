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
    public class ProductService: BaseRepository<Product> ,IProductService
    {
        public readonly ApplicationDbContext context;
        public ProductService(ApplicationDbContext _context) : base(_context)
        {
             context = _context;
        }
        public DbSet<Product> Product
        {
            get
            {
                return this.context.Product;
            }
        }
        // ham đè lại phương thức cha từ BaseRepository 
        public override async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> data = await context.Product.ToListAsync();
            return data;
        }
        public async Task<IEnumerable<Product>> Report()
        {
            IEnumerable<Product> data = await context.Product.ToListAsync();
            return data;
        }
    }
}
