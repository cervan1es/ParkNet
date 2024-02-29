using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PARKNET.Data;
using PARKNET.Data.Entities;
using PARKNET.Services;

namespace PARKNET.Pages.BalanceTopUp
{
    public class CreateModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;
        private readonly CustomerService _customerService;

        public CreateModel(PARKNET.Data.ApplicationDbContext context, CustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var customer = _customerService.GetCustomerbyEmail(User.Identity.Name);
            Transaction.CustomerID = customer.CustomerID;

            Transaction.Date = DateTime.Now;

            _context.Transaction.Add(Transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
