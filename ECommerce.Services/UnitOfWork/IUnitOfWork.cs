
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBaseRepository<Product> Product { get; }
        IBaseRepository<Address> Address { get; }
        IBaseRepository<BrandProduct> BrandProduct { get; }
        IBaseRepository<Chatelaine> Chatelaine { get; }
        IBaseRepository<City> City { get; }
        IBaseRepository<ColorClockFace> ColorClockFace { get; }
        IBaseRepository<Customer> Customer { get; }
        IBaseRepository<District> District { get; }
        IBaseRepository<Hem> Hem { get; }
        IBaseRepository<HuntingCase> HuntingCase { get; }
        IBaseRepository<Images> Images { get; }
        IBaseRepository<Machine> Machine { get; }
        IBaseRepository<MadeIn> MadeIn { get; }
        IBaseRepository<OrderItems> OrderItems { get; }
        IBaseRepository<OrderStatus> OrderStatus { get; }
        IBaseRepository<Origin> Origin { get; }
        IBaseRepository<Ward> Ward { get; }
        Task<bool> Commit();
    }
}
