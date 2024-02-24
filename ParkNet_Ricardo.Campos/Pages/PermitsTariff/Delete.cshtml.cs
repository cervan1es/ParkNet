using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Pages.PermitsTariff
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet_Ricardo.Campos.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet_Ricardo.Campos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PermitTariff PermitTariff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permittariff = await _context.PermitTariff.FirstOrDefaultAsync(m => m.ID == id);

            if (permittariff == null)
            {
                return NotFound();
            }
            else
            {
                PermitTariff = permittariff;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permittariff = await _context.PermitTariff.FindAsync(id);
            if (permittariff != null)
            {
                PermitTariff = permittariff;
                _context.PermitTariff.Remove(PermitTariff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
