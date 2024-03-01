
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data.Entities;

namespace PARKNET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Park> Park { get; set; }
        public DbSet<ParkingSpace> ParkingSpace { get; set; }
        public DbSet<Permit> Permit { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Vehicle> CustomerVehicle { get; set; }
        public DbSet<PermitTariff> PermitTariff { get; set; }
        public DbSet<PermitPurchase> PermitPurchase { get; set; }
    }
}
