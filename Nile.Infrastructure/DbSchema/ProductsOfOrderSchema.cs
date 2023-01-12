using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nile.Domain.EntityModel;

namespace Nile.Infrastructure.DbSchema
{
    public class ProductsOfOrderSchema : IEntityTypeConfiguration<ProductsOfOrder>
    {
        public void Configure(EntityTypeBuilder<ProductsOfOrder> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.ProductsOfOrders);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductsOfOrders);

        }
    }
}
