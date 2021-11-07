using MovieLibrary.Core.Models;
using System.Collections.Generic;

namespace MovieLibrary.Core.Services
{
    public interface IMovieService : ICRUDService<MovieDto>
    {
        public IEnumerable<MovieDto> Get(
            string title,
            IEnumerable<CategoryDto> categories,
            decimal minRating, decimal maxRating,
            int startId, int limit);
    }
}
