using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.Permits
{
    public class IndexModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public IndexModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Permit> Permit { get;set; } = new List<Permit>();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<ParkingSpace> ParkingSpaces { get; set; } = new List<ParkingSpace>();
        public List<Data.Entities.PermitTariff> PermitTariffs { get; set; } = new List<Data.Entities.PermitTariff>();
        public List<Park> Parks { get; set; } = new List<Park>();

        public async Task<IActionResult> OnGetAsync()
        {
            Vehicles = await _context.CustomerVehicle.ToListAsync();
            ParkingSpaces = await _context.ParkingSpace.ToListAsync();
            PermitTariffs = await _context.PermitTariff.ToListAsync();
            Parks = await _context.Park.ToListAsync();

            var customer = _context.Customer.FirstOrDefault(c => c.CustomerEmail == User.Identity.Name);
            var balance = _context.Transaction.Where(t => t.CustomerID == customer.CustomerID).Sum(t => t.Value);
            if ((int)balance <= 0) return LocalRedirect(Url.Content("~/BalanceTopUp/Create"));

            var vehicles = _context.CustomerVehicle.ToList();

            var permits = await _context.Permit.ToListAsync();
            foreach(var permit in permits)
            {
                var vehicle = vehicles.FirstOrDefault(v => v.VehicleID == permit.VehicleID);
                if(vehicle?.CustomerID == customer.CustomerID)
                {
                    Permit.Add(permit);
                }
            }

            return Page();
        }
    }
}
