using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Domain.EntityModel
{
    public class ProductsOfCartOrder
    {
        [Key]
        public int ProductsOfCartId { get; set; }

        public int? CartId { get; set; }
        public CartOrder CartOrder { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
