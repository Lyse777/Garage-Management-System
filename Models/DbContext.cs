using Microsoft.EntityFrameworkCore;

namespace Garage_Management_System.Models
{
    public class HC_Garage_DbContext : DbContext
    {
        public HC_Garage_DbContext(DbContextOptions<HC_Garage_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<RequestService> RequestService { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<SellingService> SellingServices { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestService>()
                .Property(r => r.Status)
                .HasDefaultValue("Pending"); // Set the default value

            // Or to ignore the property when saving changess
            modelBuilder.Entity<RequestService>()
                .Property(r => r.Status)
                .ValueGeneratedOnAdd();


        }

    }
}
