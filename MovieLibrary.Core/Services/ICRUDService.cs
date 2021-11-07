using System.Collections.Generic;

namespace MovieLibrary.Core.Services
{
    public interface ICRUDService<TDto>
    {
        public TDto Add(TDto entity);
        public IEnumerable<TDto> Get();
        public TDto Get(int id);
        public TDto Update(TDto entity);
        public TDto Remove(int id);
    }
}
