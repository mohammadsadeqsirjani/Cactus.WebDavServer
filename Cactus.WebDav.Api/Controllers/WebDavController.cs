using Microsoft.AspNetCore.Mvc;

namespace Cactus.WebDav.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebDavController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult HelloWorld([FromQuery] string name)
        {
            return Ok($"Hello {name}");
        }
    }
}
