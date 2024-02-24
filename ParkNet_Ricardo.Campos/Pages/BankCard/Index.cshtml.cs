using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Pages.BankCard
{
    public class IndexModel : PageModel
    {
        private readonly ParkNet_Ricardo.Campos.Data.ApplicationDbContext _context;

        public IndexModel(ParkNet_Ricardo.Campos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Entities.BankCard> BankCard { get;set; } = default!;
        public decimal Balance { get; set; } = 0;

        public async Task OnGetAsync()
        {
            BankCard = await _context.BankCard.ToListAsync();
            var transactions = await _context.Transaction.ToListAsync();
            Balance = transactions.Sum(t => t.Value);
        }
    }
}
