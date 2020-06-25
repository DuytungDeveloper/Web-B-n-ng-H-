using ECommerce.Model.EFModel;
using ECommerce.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseRepository<Product> Product { get; }
        void Commit();
    }
}
