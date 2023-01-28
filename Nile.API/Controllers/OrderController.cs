using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nile.Application.OrderHandling.OrderCommand;
using Nile.Application.DtoModels;
using Nile.Application.OrderHandling.OrderQueries;

namespace Nile.API.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderDto model)
        {
            CreateOrderCommand command = new CreateOrderCommand(
                            model.UserId,
                            model.TotalPrice,
                            model.CheckoutDate
                            );
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("AddProductTo")]
        public async Task<IActionResult> AddProductToOrder([FromBody] AddOrderDto data)
        {
            var command = new AddProductToOrderCommand(data.TotalPrice, data.CheckoutDate, data.UserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteSingleProductFrom")]
        public async Task<IActionResult> DeleteSingleProductFromOrder(int orderId)
        {
            var command = new DeleteOrderCommand(orderId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAllProductsInOrder/{Id}")]
        public async Task<IActionResult> GetAllProductsInOrder(int Id)
        {
            var query = new GetAllProductsInOrderQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllOrders/{Id}")]
        public async Task<IActionResult> GetAllOrders(int Id)
        {
            var query = new GetAllOrdersQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
