using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.ParkSetUp
{
    public class DeleteModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public DeleteModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Park Park { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park.FirstOrDefaultAsync(m => m.ParkID == id);

            if (park == null)
            {
                return NotFound();
            }
            else
            {
                Park = park;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park.FindAsync(id);
            if (park != null)
            {
                Park = park;
                _context.Park.Remove(Park);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
