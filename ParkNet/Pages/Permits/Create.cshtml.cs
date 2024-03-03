using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using PARKNET.Data;
using PARKNET.Data.Entities;
using PARKNET.Services;

namespace PARKNET.Pages.Permits
{
    public class CreateModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;
        private readonly CustomerService _customerService;
        private readonly TransactionService _transactionService;
        private readonly PermitService _permitService;

        public CreateModel(PARKNET.Data.ApplicationDbContext context, CustomerService customerService, TransactionService transactionService, PermitService permitService)
        {
            _context = context;
            _customerService = customerService;
            _transactionService = transactionService;
            _permitService = permitService;
        }

        public IActionResult OnGet()
        {
            var customer = _customerService.GetCustomerbyEmail(User.Identity.Name);
            var vehicles = _context.CustomerVehicle.Where(v => v.CustomerID == customer.CustomerID).ToList();
            if (vehicles.Count == 0) return LocalRedirect(Url.Content("~/Vehicles/Create"));

            _permitService.UpdateNotOccupiedPermits();
            _context.PermitPurchase.ExecuteDelete();
            _context.SaveChanges();


            ViewData["Vehicles"] = new SelectList(_context.CustomerVehicle.Where(v => v.CustomerID == customer.CustomerID), "VehicleID", "Plate");
            ViewData["Parks"] = new SelectList(_context.Park, "ParkID", "Name");
            ViewData["PermitTariffs"] = new SelectList(_context.PermitTariff, "PermitTariffID", "TariffType");
            return Page();
        }

        [BindProperty]
        public Permit Permit { get; set; } = default!;

        [BindProperty]
        public Guid ParkID { get; set; } = default!;




        public async Task<IActionResult> OnPostAsync()
        {
            var permitTariff = _context.PermitTariff.Find(Permit.PermitTariffID);
            var permitTariffDays = permitTariff.Days;
            
            var endDate = Permit.StartDate.AddDays(permitTariffDays);
            Permit.EndDate = endDate;

            Permit.Price = permitTariff.Price;
            bool isBalanceSufficient = _transactionService.AddTransaction(User.Identity.Name, Permit.Price);
            if (!isBalanceSufficient)
            {
                return LocalRedirect(Url.Content("~/BalanceTopUp/Create"));
            }

            var customerID = _customerService.GetCustomerbyEmail(User.Identity.Name).CustomerID;
            var permitPurchase = new PermitPurchase

            {
                CustomerID = customerID,
                ParkID = ParkID,
                PermitTariffID = Permit.PermitTariffID,
                VehicleID = Permit.VehicleID,
                StartDate = Permit.StartDate,
                EndDate = Permit.EndDate,
                Price = Permit.Price
            };

            _context.PermitPurchase.Add(permitPurchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ParkingSpaceSelect");
        }
    }
}
