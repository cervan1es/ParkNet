using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Pages.BalanceTopUp
{
    public class CreateModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ITransactionService transactionService, UserManager<ApplicationUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            var createTransactionWithSuccess = await _transactionService
                .CreateTransactionAsync(currentUser.Email, Transaction.Value, Transaction.Date);
            return RedirectToPage("./Index");
        }
    }
}
