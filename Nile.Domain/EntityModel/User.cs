
namespace Nile.Domain.EntityModel
{
    public class User 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }


        /*public virtual Payment Payment { get; set; }*/

        public List<Order> Orders { get; set; }
        public List<CartOrder> CartOrders { get; set; }
        public List<ShippingDetail> ShippingDetails { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }

    }
}
