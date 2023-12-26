using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/{version:apiVersion}/[controller]")]
public class ApiController : ControllerBase
{
}