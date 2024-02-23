using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Pages.DriversLicense
{
    public class CreateModel : PageModel
    {
        private readonly IDriversLicenseService _driversLicenseService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBankCardService _bankCardService;

        public CreateModel(IDriversLicenseService driversLicenseService,
            UserManager<ApplicationUser> userManager,
            IBankCardService bankCardService)
        {
            _driversLicenseService = driversLicenseService;
            _userManager = userManager;
            _bankCardService = bankCardService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.Entities.DriversLicense DriversLicense { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            bool createDriversLicensewithSuccess = _driversLicenseService
                .Create(currentUser?.Email, DriversLicense.ExpireDate, DriversLicense.LicenseNumber);

            var customerBankCards = _bankCardService.GetAllCustomerBankCards(currentUser?.Email);

            if (createDriversLicensewithSuccess && customerBankCards.Count == 0) return LocalRedirect(Url.Content("~/BankCard"));

            //return RedirectToPage("./Index");
            return Page();
        }
    }
}
