using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Pages.Vehicle
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet_Ricardo.Campos.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet_Ricardo.Campos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerVehicle CustomerVehicle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customervehicle = await _context.CustomerVehicle.FirstOrDefaultAsync(m => m.ID == id);

            if (customervehicle == null)
            {
                return NotFound();
            }
            else
            {
                CustomerVehicle = customervehicle;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customervehicle = await _context.CustomerVehicle.FindAsync(id);
            if (customervehicle != null)
            {
                CustomerVehicle = customervehicle;
                _context.CustomerVehicle.Remove(CustomerVehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
