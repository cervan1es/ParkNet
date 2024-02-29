using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.PermitTariff
{
    public class EditModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public EditModel(PARKNET.Data.ApplicationDbContext context)
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

            var permittariff =  await _context.PermitTariff.FirstOrDefaultAsync(m => m.PermitTariffID == id);
            if (permittariff == null)
            {
                return NotFound();
            }
            PermitTariff = permittariff;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PermitTariff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermitTariffExists(PermitTariff.PermitTariffID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PermitTariffExists(Guid id)
        {
            return _context.PermitTariff.Any(e => e.PermitTariffID == id);
        }
    }
}
