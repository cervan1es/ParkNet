using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.CustomerInfo
{
    public class CreateModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public CreateModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Customer.DriversLicenseNumber == 0 || Customer.CardNumber is null)
            {
                return Page();
            }

            Customer.CustomerEmail = User.Identity.Name;

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
