using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Nile.API.Controllers
{
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /*[HttpGet("GetAllOrdersByUserId/{userId}")]
        public async Task<IActionResult> GetAllOrdersByUserId(int userId)
        {
            return Ok();
        }*/
    }
}
