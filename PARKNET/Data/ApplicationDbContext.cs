using Microsoft.AspNetCore.Identity;
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


    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        //garantir que configuracoes padrao do ASP.NET Identity sao aplicadas antes de qualquer outra configuracao
    //        base.OnModelCreating(modelBuilder);

    //        //popular tabela de usuarios do ASP.NET Identity
    //        var adminUser = new IdentityUser { UserName = "admin@parknet.com", Email = "" };
    //        _userManager.CreateAsync(adminUser, "Admin.12345")
    //            .GetAwaiter()
    //            .GetResult();

    //        //popular tabela de roles do ASP.NET Identity
    //        var adminRole = new IdentityRole { Name = "Admin" };
    //        modelBuilder.Entity<IdentityRole>().HasData(adminRole);
            
    //        //popular tabela de relacionamento entre usuarios e roles do ASP.NET Identity, associando o usuario Admin a role Admin
    //        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = adminUser.Id });
    //    }
    }
}
