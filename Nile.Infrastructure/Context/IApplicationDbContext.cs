using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;

namespace Nile.Infrastructure.Context
{
    public interface IApplicationDbContext
    {
        #region DbSetEntities
        DbSet<User> Users { get; set; }
        DbSet<ContentFile> ContentFiles { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<ProductsOfOrder> ProductsOfOrders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ShippingDetail> ShippingDetails { get; set; }
        DbSet<PaymentDetail> PaymentDetails { get; set; }
        DbSet<CartOrder> CartOrders { get; set; }
        DbSet<ProductsOfCartOrder> ProductsOfCarts { get; set; }

        #endregion

        #region Methods
        Task<int> SaveChangesAsync();
        int SaveChanges();
        #endregion

    }
}
