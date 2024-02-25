using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Pages.Permits
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet_Ricardo.Campos.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ParkNet_Ricardo.Campos.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public List<CustomerVehicle> Vehicles { get; set; } = new();
        [BindProperty]
        public List<PermitTariff> PermitTariffs { get; set; } = new();
        [BindProperty]
        public List<Park> Parks { get; set; } = new();
        [BindProperty]
        public Park CurrentPark { get; set; } = default!;
        [BindProperty]
        public Guid CurrentParkID { get; set; }
        public Guid CurrentVehicleID { get; set; }
        public SelectList SelectOptions { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var customer = _context.Customer.FirstOrDefault(c => c.Email == currentUser.Email);
            Parks = await _context.Park.ToListAsync();
            var vehicles = _context.CustomerVehicle.Where(v => v.CustomerID == customer.ID).ToList();
            if (vehicles.Count == 0) return RedirectToPage("/Vehicle/Create");
            Vehicles = vehicles;
            var permitTariffs = _context.PermitTariff.ToList();
            PermitTariffs = permitTariffs;
            SelectOptions = new SelectList(_context.Park,nameof(Park.ID),nameof(Park.Name));
            return Page();
        }

        [BindProperty]
        public Permit Permit { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Permit.VehicleID = CurrentVehicleID;
            _context.Permit.Add(Permit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
