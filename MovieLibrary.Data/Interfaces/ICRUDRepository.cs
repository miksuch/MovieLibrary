using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Data.Interfaces
{
    public interface ICRUDRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity);
        public IEnumerable<TEntity> Get();
        public TEntity Get(int id);
        public TEntity Update(TEntity entity);
        public TEntity Remove(int id);
    }
}
