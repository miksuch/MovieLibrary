using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Repositories
{
    public class GenericRepository<TEntity> : ICRUDRepository<TEntity> where TEntity : class
    {
        private readonly MovieLibraryContext _dbContext;

        public GenericRepository(MovieLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            var result = _dbContext.Add(entity).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public TEntity Remove(int id)
        {
            var result = _dbContext.Set<TEntity>().Find(id);
            if (result != null)
            {
                _dbContext.Set<TEntity>().Remove(result);
                _dbContext.SaveChanges();
            }
            return result;
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
