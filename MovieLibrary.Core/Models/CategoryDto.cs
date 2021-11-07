using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryDto() { }
        public CategoryDto(Category category) =>
            (Id, Name) = (category.Id, category.Name);

        public static explicit operator Category(CategoryDto categoryDto)
        {
            var result = new Category();
            result.Id = categoryDto.Id;
            result.Name = categoryDto.Name;
            return result;
        }
    }
}
