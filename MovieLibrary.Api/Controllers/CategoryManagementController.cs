using MovieLibrary.Core.Models;
using MovieLibrary.Core.Services;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Api.Controllers
{
    public class CategoryManagementController : GenericController<CategoryDto>
    {
        public CategoryManagementController(ICategoryService categoryService) : base(categoryService)
        {
        }
    }
}
