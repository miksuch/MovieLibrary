using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Services;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GenericController<TDto> : Controller 
        where TDto : class
    {
        protected readonly ICRUDService<TDto> _service;

        public GenericController(ICRUDService<TDto> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpPut]
        public IActionResult Update(TDto entity)
        {
            return Ok(_service.Update(entity));
        }

        [HttpPost]
        public IActionResult Post(TDto entity)
        {
            return Ok(_service.Add(entity));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(_service.Remove(id));
        }
    }
}
