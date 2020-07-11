
using ECommerce.Model.EFModel;
using ECommerce.Model.EFModel.Models;
using ECommerce.Services.Repository;
using System.Threading.Tasks;

namespace ECommerce.Services.UnitOfWork
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        #region trannghiaqn76@gmail.com
        private ApplicationDbContext _dbContext;
        private IBaseRepository<TEntity> _Product;
        private IBaseRepository<TEntity> _Address;
        private IBaseRepository<TEntity> _BrandProduct;
        private IBaseRepository<TEntity> _Chatelaine;
        private IBaseRepository<TEntity> _City;
        private IBaseRepository<TEntity> _ColorClockFace;
        private IBaseRepository<TEntity> _Customer;
        private IBaseRepository<TEntity> _District;
        private IBaseRepository<TEntity> _Hem;
        private IBaseRepository<TEntity> _HuntingCase;
        private IBaseRepository<TEntity> _Images;
        private IBaseRepository<TEntity> _Machine;
        private IBaseRepository<TEntity> _MadeIn;
        private IBaseRepository<TEntity> _OrderItems;
        private IBaseRepository<TEntity> _OrderStatus;
        private IBaseRepository<TEntity> _Origin;
        private IBaseRepository<TEntity> _Ward;
        #endregion
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region trannghiaqn76@gmail.com
        public IBaseRepository<TEntity> Products
        {
            get
            {
                return _Product ??
                    (_Product = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Wards
        {
            get
            {
                return _Ward ?? (_Ward = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Orders
        {
            get
            {
                return _Origin ?? (_Origin = new BaseRepository<TEntity>(_dbContext));
            }
        }

        public IBaseRepository<TEntity> Origins
        {
            get
            {
                return _Origin ?? (_Origin = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> OrderStatus
        {
            get
            {
                return _OrderStatus ?? (_OrderStatus = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> OrderItems
        {
            get
            {
                return _OrderItems ?? (_OrderItems = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> MadeIns
        {
            get
            {
                return _MadeIn ?? (_MadeIn = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Machines
        {
            get
            {
                return _Machine ?? (_Machine = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Images
        {
            get
            {
                return _Images ?? (_Images = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> HuntingCases
        {
            get
            {
                return _HuntingCase ?? (_HuntingCase = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Hems
        {
            get
            {
                return _Hem ?? (_Hem = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Districts
        {
            get
            {
                return _District ?? (_District = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Customers
        {
            get
            {
                return _Customer ?? (_Customer = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> ColorClockFaces
        {
            get
            {
                return _ColorClockFace ?? (_ColorClockFace = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Citys
        {
            get
            {
                return _City ?? (_City = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Address
        {
            get
            {
                return _Address ??(_Address = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> BrandProducts
        {
            get
            {
                return _BrandProduct ?? (_BrandProduct = new BaseRepository<TEntity>(_dbContext));
            }
        }
        public IBaseRepository<TEntity> Chatelaines
        {
            get
            {
                return _Chatelaine ?? (_Chatelaine = new BaseRepository<TEntity>(_dbContext));
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
        #endregion

    }
}
