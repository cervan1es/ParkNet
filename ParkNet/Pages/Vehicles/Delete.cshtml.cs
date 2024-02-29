using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.Vehicles
{
    public class DeleteModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public DeleteModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.CustomerVehicle.FirstOrDefaultAsync(m => m.VehicleID == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                Vehicle = vehicle;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.CustomerVehicle.FindAsync(id);
            if (vehicle != null)
            {
                Vehicle = vehicle;
                _context.CustomerVehicle.Remove(Vehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
