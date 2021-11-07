using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieLibraryContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Movie> Get()
        {
            var result = _dbContext.Movies
                .Include(movie => movie.MovieCategories)
                .ThenInclude(movieCategory => movieCategory.Category);
            return result;
        }

        public override Movie Get(int id)
        {
            var result = _dbContext.Movies
                .Include(movie => movie.MovieCategories)
                .ThenInclude(movieCategory => movieCategory.Category);

            return result.FirstOrDefault(movie => movie.Id == id);
        }

        public IQueryable<Movie> FilterByTitle(IQueryable<Movie> movies, string title) =>
           movies.Where(movie => movie.Title.ToLower().Contains(title.ToLower()));

        public IQueryable<Movie> FilterByCategories(IQueryable<Movie> movies, IEnumerable<Category> categories) => 
            movies.Where(movie =>
            categories.ToList()
            .Exists(filterCategory => movie.MovieCategories.ToList()
            .Exists(movieCategory => movieCategory.CategoryId == filterCategory.Id)));

        public IQueryable<Movie> FilterByRating(IQueryable<Movie> movies, decimal minRating, decimal maxRating)
        {
            movies = movies.Where(movie =>
                movie.ImdbRating >= minRating);
            if (maxRating != default)
            {
               movies = movies.Where(movie =>
               movie.ImdbRating <= maxRating);
            }
            return movies;
        }

        public IQueryable<Movie> GetPage(IQueryable<Movie> movies, int startId, int pageSize)
        {
            movies = movies.OrderByDescending(movie => (double)movie.ImdbRating).ThenByDescending(movie => movie.Id);
            if (startId != default && pageSize != default)
            {
                var reference = movies.FirstOrDefault(movie => movie.Id == startId);
                if (reference == null)
                    reference = movies.First();

                movies = movies.Where(movie =>
                (movie.ImdbRating == reference.ImdbRating && movie.Id <= reference.Id) ||
                movie.ImdbRating < reference.ImdbRating)
                .Take(pageSize);
            }
            return movies;
        }

        public IEnumerable<Movie> Get(
            string title,
            IEnumerable<Category> categories,
            decimal minRating, decimal maxRating,
            int startId, int limit)
        {
            var result = _dbContext.Movies
                .Include(movie => movie.MovieCategories)
                .ThenInclude(movieCategory => movieCategory.Category).AsQueryable();

            if (!string.IsNullOrEmpty(title))
                result = FilterByTitle(result, title);

            if (categories.Any())
                result = FilterByCategories(result, categories);

            result = FilterByRating(result, minRating, maxRating);

            result = GetPage(result, startId, limit);
            
            return result;
        }

        public override Movie Update(Movie entity)
        {
            var dbCategories =
                _dbContext.MovieCategories
                .Where(movieCategory => movieCategory.MovieId == entity.Id);

            var updateList = new List<MovieCategory>();
            foreach( var entityCategory in entity.MovieCategories)
            {
                if (dbCategories
                    .FirstOrDefault(
                    dbCategory => dbCategory.CategoryId == entityCategory.CategoryId)
                    == null )
                {
                    updateList.Add(entityCategory);
                }
            }

            var removeList = new List<MovieCategory>();
            foreach (var dbCategory in dbCategories)
            {
                if (entity.MovieCategories
                    .FirstOrDefault(
                    entityCategory => entityCategory.CategoryId == dbCategory.CategoryId)
                    == null)
                {
                    removeList.Add(dbCategory);
                }
            }

            entity.MovieCategories.Clear();
            entity.MovieCategories = updateList;
            _dbContext.RemoveRange(removeList);
            _dbContext.Attach(entity);
            _dbContext.SaveChanges();

            return Get(entity.Id);
        }
    }
}
