using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.PermitTariff
{
    public class DeleteModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public DeleteModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Data.Entities.PermitTariff PermitTariff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permittariff = await _context.PermitTariff.FirstOrDefaultAsync(m => m.PermitTariffID == id);

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
