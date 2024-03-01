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
    public class DetailsModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public DetailsModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Permit Permit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permit.FirstOrDefaultAsync(m => m.PermitID == id);
            if (permit == null)
            {
                return NotFound();
            }
            else
            {
                Permit = permit;
            }
            return Page();
        }
    }
}
