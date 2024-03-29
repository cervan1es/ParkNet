﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.CustomerInfo
{
    public class DetailsModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public DetailsModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; } = default!;

        [BindProperty]
        public decimal Balance { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerID == id);
            var balance = await _context.Transaction.Where(t => t.CustomerID == id).SumAsync(t => t.Value);
            Balance = balance;

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
