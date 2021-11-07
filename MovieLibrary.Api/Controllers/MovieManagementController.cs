using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Models;
using MovieLibrary.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Api.Controllers
{
    public class MovieManagementController : GenericController<MovieDto>
    {
        protected readonly IMovieService _movieService;

        public MovieManagementController(IMovieService movieService) : base(movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("/v1/Movie/Filter")]
        public IActionResult Get(
            string title,
            [FromQuery] List<int> categoriesIds,
            decimal minRating, decimal maxRating,
            int startId, int limit)
        {
            var categories = categoriesIds.Select(id => new CategoryDto { Id = id }).ToList();
            return Ok(_movieService.Get(title, categories, minRating, maxRating, startId, limit));
        }
    }
}
