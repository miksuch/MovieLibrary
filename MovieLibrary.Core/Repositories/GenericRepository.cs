using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Repositories
{
    public class GenericRepository<TEntity> : ICRUDRepository<TEntity> where TEntity : class
    {
        protected readonly MovieLibraryContext _dbContext;

        public GenericRepository(MovieLibraryContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var resultEntry = _dbContext.Attach(entity);
            _dbContext.SaveChanges();
            return resultEntry.Entity;
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity Remove(int id)
        {
            var result = _dbContext.Set<TEntity>().Find(id);
            if (result != null)
            {
                _dbContext.Set<TEntity>().Remove(result);
                _dbContext.SaveChanges();
            }
            return result;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var result = _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
