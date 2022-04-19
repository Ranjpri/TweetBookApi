using Microsoft.AspNetCore.Mvc;

namespace Tweetbook.Controllers
{
    public class TestController:Controller
    {
        //Breaking changes should not be made on a endpoint
        //So we version endpoints
        //Moving this controller to a Version V1 folder
        //2 - moving controller to a folder, Then creating a route
        
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new {name = "Priya"});
        }
    }
}