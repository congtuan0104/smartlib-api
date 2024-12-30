using Microsoft.AspNetCore.Mvc;

namespace SmartLibApi.Controllers;

[Route("api/book")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Hello");
    }
}