
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Nile.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        #region DbSetEntities
        /*public DbSet<User> Users { get; set; }
        public DbSet<ContentFile> ContentFiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductsOfOrder> ProductsOfOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<CartOrder> CartOrders { get; set; }
        public DbSet<ProductsOfCartOrder> ProductsOfCarts { get; set; }*/


        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*builder.Entity<Product>(entity =>
            {
                entity.HasOne(x => x.ContentFile)
                    .WithOne(x => x.Product)
                    .HasForeignKey<Product>(x => x.FileId);

            });
            builder.Entity<Payment>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithOne(x => x.Payment)
                    .HasForeignKey<User>(x => x.Id)
                    .HasPrincipalKey<User>(x => x.Id);

            });
            builder.Entity<Payment>(entity =>
            {
                entity.HasOne(x => x.Order)
                    .WithOne(x => x.Payment)
                    .HasForeignKey<Order>(x => x.OrderId);

            });*/
        }
    }
}