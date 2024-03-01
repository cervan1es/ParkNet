using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PARKNET.Data;
using PARKNET.Data.Entities;
using PARKNET.Services;

namespace PARKNET.Pages.Permits
{
    public class CreateModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;
        private readonly CustomerService _customerService;

        public CreateModel(PARKNET.Data.ApplicationDbContext context, CustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            var customer = _customerService.GetCustomerbyEmail(User.Identity.Name);

            ViewData["Vehicles"] = new SelectList(_context.CustomerVehicle.Where(v => v.CustomerID == customer.CustomerID), "VehicleID", "Plate");
            ViewData["Parks"] = new SelectList(_context.Park, "ParkID", "Name");
            ViewData["PermitTariffs"] = new SelectList(_context.PermitTariff, "PermitTariffID", "TariffType");
            return Page();
        }

        [BindProperty]
        public Permit Permit { get; set; } = default!;

        [BindProperty]
        public Guid ParkID { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var customerID = _customerService.GetCustomerbyEmail(User.Identity.Name).CustomerID;
            var permitPurchase = new PermitPurchase
            {
                CustomerID = customerID,
                ParkID = ParkID,
                PermitTariffID = Permit.PermitTariffID,
                VehicleID = Permit.VehicleID,
                StartDate = Permit.StartDate,
                EndDate = Permit.EndDate
            };

            _context.PermitPurchase.Add(permitPurchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ParkingSpaceSelect");
        }
    }
}
