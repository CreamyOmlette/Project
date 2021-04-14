using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace DatabaseAccess
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;
        public GenericRepository(DbContext context)
        {
            _set = context.Set<TEntity>();
            _context = context;
        }
        public async Task Create(TEntity entity)
        {
            await _set.AddAsync(entity);
            
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _set.Remove(entity);
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set;
        }

        public async Task<TEntity> GetById(int id)
        {
            return  await _set
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        
    }
}
