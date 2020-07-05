
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Repository;
using System.Threading.Tasks;

namespace ECommerce.Services.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
     
        #region
        private ApplicationDbContext _dbContext;
        private IBaseRepository<Product> _Product;
        private IBaseRepository<Address> _Address;
        private IBaseRepository<BrandProduct> _BrandProduct;
        private IBaseRepository<Chatelaine> _Chatelaine;
        private IBaseRepository<City> _City;
        private IBaseRepository<ColorClockFace> _ColorClockFace;
        private IBaseRepository<Customer> _Customer;
        private IBaseRepository<District> _District;
        private IBaseRepository<Hem> _Hem;
        private IBaseRepository<HuntingCase> _HuntingCase;
        private IBaseRepository<Images> _Images;
        private IBaseRepository<Machine> _Machine;
        private IBaseRepository<MadeIn> _MadeIn;
        private IBaseRepository<OrderItems> _OrderItems;
        private IBaseRepository<OrderStatus> _OrderStatus;
        private IBaseRepository<Origin> _Origin;
        private IBaseRepository<Ward> _Ward;
        #endregion

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }
        public IBaseRepository<Ward> Ward
        {
            get
            {
                return _Ward ?? (_Ward = new BaseRepository<Ward>(_dbContext));
            }
        }
        public IBaseRepository<Origin> Origin
        {
            get
            {
                return _Origin ?? (_Origin = new BaseRepository<Origin>(_dbContext));
            }
        }
        public IBaseRepository<OrderStatus> OrderStatus
        {
            get
            {
                return _OrderStatus ?? (_OrderStatus = new BaseRepository<OrderStatus>(_dbContext));
            }
        }
        public IBaseRepository<OrderItems> OrderItems
        {
            get
            {
                return _OrderItems ?? (_OrderItems = new BaseRepository<OrderItems>(_dbContext));
            }
        }
        public IBaseRepository<MadeIn> MadeIn
        {
            get
            {
                return _MadeIn ?? (_MadeIn = new BaseRepository<MadeIn>(_dbContext));
            }
        }
        public IBaseRepository<Machine> Machine
        {
            get
            {
                return _Machine ?? (_Machine = new BaseRepository<Machine>(_dbContext));
            }
        }
        public IBaseRepository<Images> Images
        {
            get
            {
                return _Images ?? (_Images = new BaseRepository<Images>(_dbContext));
            }
        }
        public IBaseRepository<HuntingCase> HuntingCase
        {
            get
            {
                return _HuntingCase ?? (_HuntingCase = new BaseRepository<HuntingCase>(_dbContext));
            }
        }
        public IBaseRepository<Hem> Hem
        {
            get
            {
                return _Hem ?? (_Hem = new BaseRepository<Hem>(_dbContext));
            }
        }
        public IBaseRepository<District> District
        {
            get
            {
                return _District ?? (_District = new BaseRepository<District>(_dbContext));
            }
        }
        public IBaseRepository<Customer> Customer
        {
            get
            {
                return _Customer ?? (_Customer = new BaseRepository<Customer>(_dbContext));
            }
        }
        public IBaseRepository<ColorClockFace> ColorClockFace
        {
            get
            {
                return _ColorClockFace ?? (_ColorClockFace = new BaseRepository<ColorClockFace>(_dbContext));
            }
        }
        public IBaseRepository<City> City
        {
            get
            {
                return _City ?? (_City = new BaseRepository<City>(_dbContext));
            }
        }
        public IBaseRepository<Address> Address
        {
            get
            {
                return _Address ??(_Address = new BaseRepository<Address>(_dbContext));
            }
        }
        public IBaseRepository<BrandProduct> BrandProduct
        {
            get
            {
                return _BrandProduct ?? (_BrandProduct = new BaseRepository<BrandProduct>(_dbContext));
            }
        }
        public IBaseRepository<Chatelaine> Chatelaine
        {
            get
            {
                return _Chatelaine ?? (_Chatelaine = new BaseRepository<Chatelaine>(_dbContext));
            }
        }
        public IBaseRepository<Product> Product
        {
            get
            {
                return _Product ??
                    (_Product = new BaseRepository<Product>(_dbContext));
            }
        }
        public async Task<bool> Commit()
        {
            try
            {
               await  _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
       
    }
}
