using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAccess.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        public Task Create(TEntity entity);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task Delete(int id);
        public Task Delete(TEntity entity);
        public Task Update(TEntity entity);
        public Task<TEntity> GetById(int id);
        public Task SaveChangesAsync();
    }
}