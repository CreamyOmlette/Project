using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
namespace WebApi
{
    interface IGenericRepository<TEntity> where TEntity: IEntity
    {
        public IQueryable<TEntity> GetAll();

        public Task<TEntity> GetById(int id);

        public Task Create(TEntity entity);

        public Task Update(int id, TEntity entity);

        public Task Delete(int id);
    }
}
