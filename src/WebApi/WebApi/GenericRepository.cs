using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
namespace WebApi
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IEntity
    {
        private DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return  await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
