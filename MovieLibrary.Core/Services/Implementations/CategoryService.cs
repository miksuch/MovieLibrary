using MovieLibrary.Core.Models;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Core.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDto Add(CategoryDto entity)
        {
            if (entity.Id != default)
                throw new InvalidOperationException();

            return new CategoryDto(_categoryRepository.Add((Category)entity));
        }

        public IEnumerable<CategoryDto> Get()
        {
            return _categoryRepository.Get().Select(category => new CategoryDto(category));
        }

        public CategoryDto Get(int id)
        {
            return new CategoryDto(_categoryRepository.Get(id));
        }

        public CategoryDto Remove(int id)
        {
            return new CategoryDto(_categoryRepository.Remove(id));
        }

        public CategoryDto Update(CategoryDto entity)
        {
            if (entity.Id == default)
                throw new InvalidOperationException();

            return new CategoryDto(_categoryRepository.Update((Category)entity));
        }
    }
}
