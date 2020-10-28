using Microsoft.AspNetCore.Mvc;
using StrategyExample.Models;
using StrategyExample.Services;

namespace StrategyExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _service;

        public ExampleController(IExampleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Example([FromQuery] ExampleRequest request)
        {
            var result = _service.Process(request);
            return Ok(result);
        }
    }
}
