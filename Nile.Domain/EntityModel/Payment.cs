using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nile.Domain.EntityModel
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Succeeded { get; set; }
        public string PaymentMethod { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }


        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
