using ECommerce.Model.Result;
using ECommerce.Model.EFModel;
using ECommerce.Services.Interfaces;
using ECommerce.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Implements
{
    public class ProductService:IProductService
    {
        private readonly EcommerceContext _context;
        private readonly IUnitOfWork _IUnitOfWork;
        public ProductService(EcommerceContext context, IUnitOfWork IUnitOfWork)
        {
            _context = context;
            _IUnitOfWork = IUnitOfWork;
        }
        public DbSet<Product> Product
        {
            get
            {
                return this._context.Product;
            }
        }

        public async Task<ResultListData<Product>> Get(int id = 0)
        {
            ResultListData<Product> result = new ResultListData<Product>();
            try
            {
                List<Product> GetAll = _context.Product.ToList();
                GetAll = id == 0 ? GetAll : GetAll.Where(x => x.Id == id).ToList();
                result.Amount = GetAll.Count();
                result.Data = GetAll;
                result.Message = GetAll.Count() > 0 ? "Thành Công !" : "Thất Bại ! ";
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.Data = null;
                result.Message =  ex.Message;
                result.Success = false;
            }
            return result;
        }
        public async Task<ResultData<Product>> Add(Product Item)
        {
            ResultData<Product> result = new ResultData<Product>();
            try
            {
                 _context.Product.Add(Item);
                _context.SaveChanges();
                result.Data = Item;
                result.Message = Item.Id > 0 ? "Thành Công !":"Thất Bại ! ";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = ex.Message;
                result.Success = true;
            }
            return result;
        }
        public async Task<ResultListData<Product>>Add(List<Product> LsI)
        {
           ResultListData<Product> result = new ResultListData<Product>();
            try
            {
                
                if (LsI.Count > 501)
                {
                    result.Data = null;
                    result.Message = "Dữ liệu tạo không vượt quá 500 dòng ! ";
                    result.Success = false;
                }
                else
                {

                    var Option = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 10
                    };
                    Parallel.ForEach(LsI, Option,Item =>{ _IUnitOfWork.Product.Insert(Item);});
                    _IUnitOfWork.Commit();
                }
                result.Data = LsI;
                result.Message = "Thành công !";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
        public async Task<ResultData<Product>> Update(Product Item)
        {
            ResultData<Product> result = new ResultData<Product>();
            try
            {
               
                _context.Product.Update(Item);
                await _context.SaveChangesAsync();
                result.Data = Item;
                result.Message = "Thành công ! ";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = ex.Message;
                result.Success = true;
            }
            return result;
        }
        public async Task<ResultData<Product>> Delete(Product Item)
        {
            ResultData<Product> result = new ResultData<Product>();
            try
            {
                _context.Product.Update(Item);
                _context.SaveChanges();
                result.Data = Item;
                result.Message = "Thành công !";
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = ex.Message;
                result.Success = true;
            }
            return result;
        }

    }
}
