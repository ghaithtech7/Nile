
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nile.Domain.EntityModel;

namespace Nile.Infrastructure.DbSchema
{
    public class ProductsOfCartOrderSchema : IEntityTypeConfiguration<ProductsOfCartOrder>
    {
        public void Configure(EntityTypeBuilder<ProductsOfCartOrder> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.ProductsOfCartOrders);
            builder.HasOne(x => x.CartOrder).WithMany(x => x.ProductsOfCartOrders);

        }
    }
}
