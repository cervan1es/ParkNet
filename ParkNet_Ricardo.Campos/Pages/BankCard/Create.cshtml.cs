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

namespace ParkNet_Ricardo.Campos.Pages.BankCard
{
    public class CreateModel : PageModel
    {
        private readonly IBankCardService _bankCardService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IBankCardService bankCardService, UserManager<ApplicationUser> userManager)
        {
            _bankCardService = bankCardService;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.Entities.BankCard BankCard { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var createBankCarWithSuccess = _bankCardService
                .CreateBankCard(currentUser.Email, BankCard.CardNumber, BankCard.ExpireDate);

            if(createBankCarWithSuccess) return LocalRedirect(Url.Content("~/"));

            return RedirectToPage("./Index");
        }
    }
}
