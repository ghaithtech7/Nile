using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Domain.EntityModel
{
    public class ShippingDetail
    {
        [Key]
        public int ShippindId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ContactNumber { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public List<Order> Orders { get; set; }
    }
}