using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using DatabaseAccess.Interfaces;
using DatabaseAccess.Interfaces;

namespace DatabaseAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Set;
        public GenericRepository(DbContext context)
        {
            Set = context.Set<TEntity>();
            Context = context;
        }
        public virtual async Task Create(TEntity entity)
        {
            await Set.AddAsync(entity);
            
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            Set.Remove(entity);
        }
        
        public virtual async Task Delete(TEntity entity)
        {
            await Task.Run(() => Set.Remove(entity));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
             return await Task.Run(() => Set);
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return  (await Set
                .FirstOrDefaultAsync(obj => obj.Id == id));
        }

        public virtual async Task Update(TEntity entity)
        {
            await Task.Run(() => Set.Update(entity));
        }

        public virtual async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
        
        
    }
}
