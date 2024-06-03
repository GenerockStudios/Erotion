using Microsoft.AspNetCore.Mvc;

namespace Erotion.API.Presentation.Controllers
{
    [Route("users")]
    public class UserController: Controller
    {
        public UserController() { }


        [HttpGet]
        public IActionResult Index() 
        {
            return Ok("Users is okay");
        }

       
    }
}
