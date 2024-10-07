using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class REST : ControllerBase
    {
        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<string> Get(string user )
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //         = $"Hello, {request}!"

        //    })
        //    .ToArray();
        //}


        [HttpGet("{Blazor}")]
        public IActionResult GetUser(string  Blazor)
        {
           
            return Ok(Blazor);
        }

        [HttpPost("REST")]
        public async Task<ActionResult<string>> PostAccount([FromBody]  string systemAccount)
        {
            systemAccount = $"Hello, {systemAccount}!";

            return CreatedAtAction(nameof(GetUser), new { Blazor = systemAccount }, systemAccount);
        }
    }
}
