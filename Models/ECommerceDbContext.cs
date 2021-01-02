using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Models
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext():base("ECommerceDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ECommerceDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey<int>(k => k.AdminId);
            modelBuilder.Entity<Category>().HasKey<int>(k => k.CategoryId);
            modelBuilder.Entity<Customer>().HasKey<int>(k => k.CustomerId);
            modelBuilder.Entity<Offer>().HasKey<int>(k => k.OfferId);
            modelBuilder.Entity<Order>().HasKey<int>(k => k.OrderId);
            modelBuilder.Entity<OrderedItem>().HasKey<int>(k => k.OrderedItemId);
            modelBuilder.Entity<Product>().HasKey<int>(k => k.ProductId);
            modelBuilder.Entity<Shipper>().HasKey<int>(k => k.ShipperId);
            modelBuilder.Entity<WishlistItem>().HasKey<int>(k => k.WishlistItemId);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
    }
}