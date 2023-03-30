using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BanDieuFood.Models
{
    public partial class BanDieuDBContext : DbContext
    {
        public BanDieuDBContext()
            : base("name=BanDieuDBContext1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup_Role> UserGroup_Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.PriceAtDetail)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserGroup_Role)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserGroup_Role)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
