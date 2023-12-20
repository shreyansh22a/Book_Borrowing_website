using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Modals;

namespace Data_Access_Layer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.LentByUser)
                .WithMany(u => u.BooksLent)
                .HasForeignKey(b => b.LentByUserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict); // Updated to DeleteBehavior.Restrict

            modelBuilder.Entity<Book>()
            .HasOne(b => b.CurrentlyBorrowedByUser)
            .WithMany()
            .HasForeignKey(b => b.CurrentlyBorrowedById)
            .OnDelete(DeleteBehavior.SetNull);  // Set to null on delete


            // Additional configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
