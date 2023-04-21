using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorController : ControllerBase
{
    [OnError]
    public IActionResult Error()
    {
        return Problem(title: "Internal Server Error", detail: "An internal server error has occured.");
    }
}
