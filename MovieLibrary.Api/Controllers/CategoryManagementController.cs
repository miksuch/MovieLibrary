using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Api.Controllers
{
    public class CategoryManagementController : GenericController<Category, ICategoryRepository>
    {
        public CategoryManagementController(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
