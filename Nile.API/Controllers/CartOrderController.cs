using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nile.Application.DtoModels;
using Nile.Application.CartOrderHandling.CartOrderCommand;
using Nile.Application.CartOrderHandling.CartOrderQuery;

namespace Nile.API.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class CartOrderController : Controller
    {
        private readonly IMediator _mediator;
        public CartOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCartOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CartOrderDto model)
        {
            CreateCartOrderCommand command = new CreateCartOrderCommand(
                            model.UserId,
                            model.TotalPrice,
                            model.ProductsOfCartOrdersId
                            );
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("AddProductTo")]
        public async Task<IActionResult> AddProductTo([FromBody] AddCartOrderDto data)
        {
            var command = new AddProductToCartCommand(data.CartId, data.ProductId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteSingleProductFrom")]
        public async Task<IActionResult> DeleteSingleProductFrom(int Id, int productId)
        {
            var command = new DeleteSingleProductFromCartCommand(Id, productId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAllProductsIn/{Id}")]
        public async Task<IActionResult> GetAllProductsIn(int Id)
        {
            var query = new GetAllProductsInCartQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
