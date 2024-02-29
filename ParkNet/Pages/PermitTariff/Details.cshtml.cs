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
    public class DetailsModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public DetailsModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
