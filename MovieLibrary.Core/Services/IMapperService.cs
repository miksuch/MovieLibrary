using System.Collections.Generic;

namespace MovieLibrary.Core.Services
{
    public interface IMapperService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        public IEnumerable<TDto> Map(IEnumerable<TEntity> entities);
        public TDto Map(TEntity entity);
    }
}
