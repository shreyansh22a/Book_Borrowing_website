using DataAccessLayer.modals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }

       

        public void SeedUsers()
        {
            // Check if any users exist, and only seed if none are found
            if (!Users.Any())
            {
                

                // Seed your users here
                var adminUser = new User
                {
                    Id = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Administrator",
                    IsAdmin = true,
                    Password = "Admin1@"


                };

                var user = new User
                {
                    Id = "user@gmail.com", 
                    FirstName = "User",
                    LastName = "NormalUser",
                    IsAdmin = false,
                    Password="User1@"
                    
                };

                Users.Add(adminUser);
                Users.Add(user);

                SaveChanges();
            }
        }
    }


}
