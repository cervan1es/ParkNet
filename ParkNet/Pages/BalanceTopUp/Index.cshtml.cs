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

        public async Task OnGetAsync()
        {
            Transaction = await _context.Transaction.ToListAsync();
            Balance = Transaction.Sum(t => t.Value);
        }
    }
}
