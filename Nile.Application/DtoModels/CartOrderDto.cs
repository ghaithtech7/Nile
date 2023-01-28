using Nile.Domain.EntityModel;

namespace Nile.Application.DtoModels
{
    public class CartOrderDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        public List<int> ProductsOfCartOrdersId { get; set; }
    }

    public class AddCartOrderDto
    {
        public int CartId { get; set;}
        public int ProductId { get; set;}
    }
}
