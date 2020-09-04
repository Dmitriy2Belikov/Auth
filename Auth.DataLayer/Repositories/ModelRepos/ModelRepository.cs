using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.DataLayer.Repositories.ModelRepos
{
    public class ModelRepository<TEntity> : IModelRepository<TEntity>
        where TEntity : class
    {
        private UserDbContext _context;
        private DbSet<TEntity> _entities;

        public ModelRepository(UserDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);

            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);

            _context.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);

            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);

            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);

            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _entities.Find(id);

            _entities.Remove(entity);

            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);

            _context.SaveChanges();
        }

        public bool Contains(Guid id)
        {
            var entity = _entities.Find(id);

            return entity != null ? true : false;
        }
    }
}
