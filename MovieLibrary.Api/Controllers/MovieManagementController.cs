using MovieLibrary.Core.Repositories;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Api.Controllers
{
    public class MovieManagementController : GenericController<Movie, IMovieRepository>
    {
        public MovieManagementController(IMovieRepository repository) : base(repository)
        {
        }
    }
}
