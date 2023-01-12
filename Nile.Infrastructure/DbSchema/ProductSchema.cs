using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nile.Domain.EntityModel;

namespace Nile.Infrastructure.DbSchema
{
    public class ProductSchema : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.HasOne(x => x.ContentFile)
                    .WithOne(x => x.Product)
                    .HasForeignKey<Product>(x => x.FileId);
        }
    }
}
