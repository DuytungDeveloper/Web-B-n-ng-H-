using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using ECommerce.Services.Repository;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        private EcommerceContext _dbContext;
        private IBaseRepository<Product> _Product;

        public UnitOfWork(EcommerceContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public IBaseRepository<Product> Product
        {
            get
            {
                return _Product ??
                    (_Product = new BaseRepository<Product>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
