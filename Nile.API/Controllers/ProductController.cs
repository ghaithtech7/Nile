using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nile.Application.DtoModels;
using Nile.Application.ProductHandling.ProductCommand;
using Nile.Application.ProductHandling.ProductQueries;

namespace Nile.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var command = new DeleteProductCommand(productId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = _mediator.Send(query);
            return Ok(result);
        }
    }
}
