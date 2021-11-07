using MovieLibrary.Core.Models;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Core.Services.Implementations
{
    public class CategoryMapper : IMapperService<Category, CategoryDto>
    {
        public IEnumerable<CategoryDto> Map(IEnumerable<Category> entities)
        {
            var mappedEntities = new List<CategoryDto>();
            foreach (var entity in entities)
            {
                mappedEntities.Add(Map(entity));
            }
            return mappedEntities;
        }

        public CategoryDto Map(Category entity)
        {
            return new CategoryDto(entity);
        }
    }
}
