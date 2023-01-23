
using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;

namespace Nile.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }


        #region DbSetEntities
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ContentFile> ContentFiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductsOfOrder> ProductsOfOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<CartOrder> CartOrders { get; set; }
        public DbSet<ProductsOfCartOrder> ProductsOfCarts { get; set; }
        
        public int SaveChanges()
        {
            int number = this.SaveChanges(true);
            return number;
        }
        public async Task<int> SaveChangesAsync()
        {
            int number = await this.SaveChangesAsync(true);
            return number;
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.HasOne(x => x.ContentFile)
                    .WithOne(x => x.Product)
                    .HasForeignKey<Product>(x => x.FileId);

            });
            builder.Entity<UserRole>(entity =>
            {
                entity.HasKey(x => x.UserRoleId);
                entity.HasOne(x => x.User).WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Role).WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleId);
            });
        }
    }
}