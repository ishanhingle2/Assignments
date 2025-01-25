using Microsoft.AspNetCore.Mvc;

namespace Stocks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StocksController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get(){
        return Ok();
    }
}
