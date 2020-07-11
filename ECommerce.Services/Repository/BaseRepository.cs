using ECommerce.Model.EFModel;
using ECommerce.Services.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public readonly ApplicationDbContext context;
        public readonly DbSet<TEntity> dbSet;
        public BaseRepository(ApplicationDbContext _context)
        {
            this.context = _context;
            this.dbSet = this.context.Set<TEntity>();
        }
        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            var _type = typeof(TEntity);
            var _fi = _type.GetFields();
            var _pi = _type.GetProperties();
            var _ordinalMap = new Dictionary<string, int>();

            return await dbSet.ToListAsync();
        }
        public  async virtual Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async virtual Task<TEntity> Insert(TEntity entityToInsert, bool SaveChangesAsync)
        {
            try
            {
                await dbSet.AddAsync(entityToInsert);
                if (SaveChangesAsync)
                    await context.SaveChangesAsync();
                return entityToInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async virtual Task<TEntity> Update(TEntity entityToUpdate, bool SaveChangesAsync)
        {
            try
            {
                this.dbSet.Update(entityToUpdate);
                if (SaveChangesAsync)
                    await context.SaveChangesAsync();
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async virtual Task<TEntity> Delete(TEntity entityToDelete, bool SaveChangesAsync)
        {
            dbSet.Update(entityToDelete);
            if (SaveChangesAsync)
                await context.SaveChangesAsync();
            return entityToDelete;
        }
    }
} 
