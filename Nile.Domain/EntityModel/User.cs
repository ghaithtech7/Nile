
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Nile.Domain.EntityModel
{
    [Index(nameof(Email), IsUnique = true)]
    public class User 
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }


        public virtual Payment Payment { get; set; }

        public List<Order> Orders { get; set; }
        public List<CartOrder> CartOrders { get; set; }
        public List<ShippingDetail> ShippingDetails { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
