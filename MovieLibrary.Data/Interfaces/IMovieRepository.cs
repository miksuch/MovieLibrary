using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Data.Interfaces
{
    public interface IMovieRepository : ICRUDRepository<Movie>
    {
        public IEnumerable<Movie> Get(
            string title,
            IEnumerable<Category> categories,
            decimal minRating, decimal maxRating,
            int startId, int limit);
    }
}
