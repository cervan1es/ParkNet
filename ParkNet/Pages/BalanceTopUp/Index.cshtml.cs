using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.BalanceTopUp
{
    public class IndexModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public IndexModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; } = default!;
        public decimal Balance { get; set; }
        public bool HasPermits { get; set; } = false;

        public async Task OnGetAsync()
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.CustomerEmail.Equals(User.Identity.Name));
            var vehicles = _context.CustomerVehicle.Where(v => v.CustomerID == customer.CustomerID).ToList();

            for (int i = 0; i < vehicles.Count; i++)
            {
                var permits = _context.Permit.Where(p=>p.VehicleID == vehicles[i].VehicleID).ToList();
                if (permits.Count > 0)
                {
                    foreach (var permit in permits)
                    {
                        if (permit.EndDate > DateTime.Now)
                        {
                            HasPermits = true;
                            break;
                        }
                    }
                }
            }

            Transaction = await _context.Transaction.ToListAsync();
            Balance = Transaction.Sum(t => t.Value);
        }



        public IActionResult OnGetWithdraw()
        {
            var customer = _context.Customer.FirstOrDefault(c=>c.CustomerEmail.Equals(User.Identity.Name));
            var transactions = _context.Transaction.Where(t => t.CustomerID == customer.CustomerID).ToList();
            var balance = transactions.Sum(t => t.Value);
            if (balance >0)
            {
                var transaction = new Transaction
                {
                    CustomerID = customer.CustomerID,
                    Value = -balance,
                    Date = DateTime.Now
                };
                _context.Transaction.Add(transaction);
                _context.SaveChanges();                
            }
            return RedirectToPage("./Index");
        }
    }
}
