using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Domain.EntityModel
{
    public class PaymentDetail
    {
        public int PaymentDetailId { get; set; }
        public int PaymentCardNumber { get; set; }
        public string NameOnPaymentCard { get; set; }
        public DateTime PaymentCardExipration { get; set; }
        public int CCV { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
