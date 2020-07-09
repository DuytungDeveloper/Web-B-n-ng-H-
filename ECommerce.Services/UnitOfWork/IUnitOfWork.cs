
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Services.UnitOfWork
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {

        IBaseRepository<TEntity> Product { get; }
        IBaseRepository<TEntity> Address { get; }
        IBaseRepository<TEntity> BrandProduct { get; }
        IBaseRepository<TEntity> Chatelaine { get; }
        IBaseRepository<TEntity> City { get; }
        IBaseRepository<TEntity> ColorClockFace { get; }
        IBaseRepository<TEntity> Customer { get; }
        IBaseRepository<TEntity> District { get; }
        IBaseRepository<TEntity> Hem { get; }
        IBaseRepository<TEntity> HuntingCase { get; }
        IBaseRepository<TEntity> Images { get; }
        IBaseRepository<TEntity> Machine { get; }
        IBaseRepository<TEntity> MadeIn { get; }
        IBaseRepository<TEntity> OrderItems { get; }
        IBaseRepository<TEntity> OrderStatus { get; }
        IBaseRepository<TEntity> Orders { get; }
        IBaseRepository<TEntity> Origin { get; }
        IBaseRepository<TEntity> Ward { get; }
        Task<bool> Commit();
    }
}
