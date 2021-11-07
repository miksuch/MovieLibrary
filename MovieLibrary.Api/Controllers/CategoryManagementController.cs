using MovieLibrary.Core.Models;
using MovieLibrary.Core.Services;

namespace MovieLibrary.Api.Controllers
{
    public class CategoryManagementController : GenericController<CategoryDto>
    {
        public CategoryManagementController(ICategoryService categoryService) : base(categoryService)
        {
        }
    }
}
