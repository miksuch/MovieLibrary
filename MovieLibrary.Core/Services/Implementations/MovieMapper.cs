using MovieLibrary.Core.Models;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Core.Services.Implementations
{
    public class MovieMapper : IMapperService<Movie, MovieDto>
    {
        public IEnumerable<MovieDto> Map(IEnumerable<Movie> entities)
        {
            var mappedEntities = new List<MovieDto>();
            foreach (var entity in entities)
            {
                mappedEntities.Add(Map(entity));
            }
            return mappedEntities;
        }

        public MovieDto Map(Movie entity)
        {
            return new MovieDto(entity);
        }
    }
}
