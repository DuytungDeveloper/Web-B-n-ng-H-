using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id = 0);
        Task<TEntity> Insert(TEntity entityToInsert, bool SaveChangesAsync = false);
        Task<TEntity> Update(TEntity entityToUpdate, bool SaveChangesAsync = false);
        Task<TEntity> Delete(TEntity entityToUpdate, bool SaveChangesAsync = false);


    }
}
