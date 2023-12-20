using DataAccessLayer.models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Cart> Carts { get; set; } 
        public DbSet<Order> Orders { get; set; }

        public DbSet<Ratings> Rating { get; set; }


        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.CartID);

            modelBuilder.Entity<Review>()
                .HasKey(c => c.ID);


            modelBuilder.Entity<Ratings>()
                .HasKey(c => c.RatingID);


            // Configure other properties and mappings for the Cart entity

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);

            // Configure other properties and mappings for the Order entity

            base.OnModelCreating(modelBuilder);
        }
    }
}
