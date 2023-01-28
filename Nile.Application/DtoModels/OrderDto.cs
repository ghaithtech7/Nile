
namespace Nile.Application.DtoModels
{
    public class AddOrderDto
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
