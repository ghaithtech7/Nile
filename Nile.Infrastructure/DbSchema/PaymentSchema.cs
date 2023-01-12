
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nile.Domain.EntityModel;

namespace Nile.Infrastructure.DbSchema
{
    public class PaymentSchema : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            /*builder.HasOne(x => x.Order).WithOne(x => x.Payment);
            builder.HasOne(x => x.User).WithOne(x => x.Payment);*/
        }
    }
}
