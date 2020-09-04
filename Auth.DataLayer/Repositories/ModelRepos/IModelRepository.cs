using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.DataLayer.Repositories.ModelRepos
{
    public interface IModelRepository<TEntity>
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<TEntity> entities);
        bool Contains(Guid id);
    }
}
