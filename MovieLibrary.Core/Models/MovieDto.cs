using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public MovieDto() { }
        public MovieDto(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Description = movie.Description;
            this.Year = movie.Year;
            this.ImdbRating = movie.ImdbRating;
            this.Categories = movie.MovieCategories.Select(movieCategory => new CategoryDto(movieCategory.Category)).ToList();
        }

        public static explicit operator Movie(MovieDto movieDto)
        {
            var result = new Movie();
            result.Id = movieDto.Id;
            result.Title = movieDto.Title;
            result.Description = movieDto.Description;
            result.Year = movieDto.Year;
            result.ImdbRating = movieDto.ImdbRating;
            foreach( var category in movieDto.Categories )
            {
                var movieCategory = new MovieCategory();
                movieCategory.CategoryId = category.Id;
                movieCategory.MovieId = movieDto.Id;
                movieCategory.Movie = result;
                movieCategory.Category = (Category)category;
                result.MovieCategories.Add(movieCategory);
            }
            return result;
        }
    }
}
