using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data.Entities;
namespace ParkNet_Ricardo.Campos.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Park> Park { get; set; }
        public DbSet<ParkingSpace> ParkingSpace { get; set; }
        public DbSet<Permit> Permit { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicle { get; set; }
        public DbSet<DriversLicense> DriversLicense { get; set; }
        public DbSet<BankCard> BankCard { get; set; }
        public DbSet<TicketTariff> TicketTariff { get; set; }
        public DbSet<PermitTariff> PermitTariff { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
