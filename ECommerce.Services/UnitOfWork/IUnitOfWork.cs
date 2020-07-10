
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Services.UnitOfWork
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {

        IBaseRepository<TEntity> Products { get; }
        IBaseRepository<TEntity> Address { get; }
        IBaseRepository<TEntity> BrandProducts { get; }
        IBaseRepository<TEntity> Chatelaines { get; }
        IBaseRepository<TEntity> Citys { get; }
        IBaseRepository<TEntity> ColorClockFaces { get; }
        IBaseRepository<TEntity> Customers { get; }
        IBaseRepository<TEntity> Districts { get; }
        IBaseRepository<TEntity> Hems { get; }
        IBaseRepository<TEntity> HuntingCases { get; }
        IBaseRepository<TEntity> Images { get; }
        IBaseRepository<TEntity> Machines { get; }
        IBaseRepository<TEntity> MadeIns { get; }
        IBaseRepository<TEntity> OrderItems { get; }
        IBaseRepository<TEntity> OrderStatus { get; }
        IBaseRepository<TEntity> Orders { get; }
        IBaseRepository<TEntity> Origins { get; }
        IBaseRepository<TEntity> Wards { get; }
        Task<bool> Commit();
    }
}
