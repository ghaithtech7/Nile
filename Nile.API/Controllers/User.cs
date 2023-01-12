using Microsoft.AspNetCore.Mvc;

namespace Nile.API.Controllers
{
    [Route("api/[Controller]")]
    public class User : Controller
    {
        [HttpGet("GetUser")]
        public string GetUser()
        {
            string s = HttpContext.User.Identity.Name;
            return s;
        }
    }
}
