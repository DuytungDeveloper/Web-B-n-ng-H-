﻿using ECommerce.Model.EFModel;
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
        internal new ApplicationDbContext context;
        public ProductService(ApplicationDbContext _context) : base(_context)
        {
            this.context = _context;
        }
        public override async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> data = await context.Product.ToListAsync();
            return data;
        
        }
    }
}
