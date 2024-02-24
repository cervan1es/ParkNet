using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Pages.BalanceTopUp
{
    public class IndexModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ITransactionService transactionService, UserManager<ApplicationUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        public IList<Transaction> Transaction { get;set; } = default!;
        [BindProperty]
        public decimal Balance { get; set; } = 0;

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            Balance = await _transactionService.GetBalanceByCustomerAsync(currentUser.Email);
            Transaction = await _transactionService.GetTransactionsByCustomerAsync(currentUser.Email);
        }
    }
}
