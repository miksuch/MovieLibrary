using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GenericController<TEntity, TRepository> : Controller 
        where TEntity : class
        where TRepository : ICRUDRepository<TEntity>
    {
        private readonly TRepository _repository;

        public GenericController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpPut]
        public IActionResult Update(TEntity entity)
        {
            return Ok(_repository.Update(entity));
        }

        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            return Ok(_repository.Add(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(_repository.Remove(id));
        }
    }
}
