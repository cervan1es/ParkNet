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
    public class IndexModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public IndexModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Permit> Permit { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerEmail == User.Identity.Name);
            var balance = _context.Transaction.Where(t => t.CustomerID == customer.CustomerID).Sum(t => t.Value);
            if ((int)balance <= 0) return LocalRedirect(Url.Content("~/BalanceTopUp/Create"));

            Permit = await _context.Permit.ToListAsync();
            return Page();
        }
    }
}
