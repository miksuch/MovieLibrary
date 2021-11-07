using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        [HttpGet("")]
        public IActionResult Index() => Problem();
    }
}
