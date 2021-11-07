using MovieLibrary.Core.Models;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieDto Add(MovieDto entity)
        {
            if (entity.Id != default)
                throw new InvalidOperationException();

            return new MovieDto(_movieRepository.Add((Movie)entity));
        }

        public IEnumerable<MovieDto> Get(
            string title,
            IEnumerable<CategoryDto> categories,
            decimal minRating, decimal maxRating,
            int startId, int limit)
        {
            return _movieRepository.Get(
                title,
                categories.Select(categoryDto => (Category)categoryDto),
                minRating, maxRating,
                startId, limit)
                .Select(movie => new MovieDto(movie));
        }

        public IEnumerable<MovieDto> Get()
        {
            return _movieRepository.Get().Select(movie => new MovieDto(movie));
        }

        public MovieDto Get(int id)
        {
            return new MovieDto(_movieRepository.Get(id));
        }

        public MovieDto Remove(int id)
        {
            return new MovieDto(_movieRepository.Remove(id));
        }

        public MovieDto Update(MovieDto entity)
        {
            if (entity.Id == default)
                throw new InvalidOperationException();

            return new MovieDto(_movieRepository.Update((Movie)entity));
        }
    }
}
