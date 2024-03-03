using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.Profit
{
    public class ProfitModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public ProfitModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Permit> Permit { get;set; } = default!;
        public decimal Profit { get; set; }

        public async Task OnGetAsync()
        {
            Permit = await _context.Permit.ToListAsync();
            Profit = Permit.Sum(p => p.Price);
        }
    }
}
