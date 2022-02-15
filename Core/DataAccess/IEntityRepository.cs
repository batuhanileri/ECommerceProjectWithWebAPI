using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity 
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression);
        //IEnumerable birden fazla kayıt varsa dönmeyi sağlar

        // category.SingleOrDefaultAsync(x=>x.name="kalem") vs.
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities); //Birden fazla kayıt olabilir.
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void Add(TEntity entity);
    }
}
