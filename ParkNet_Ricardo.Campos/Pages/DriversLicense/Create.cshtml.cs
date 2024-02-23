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
using ParkNet_Ricardo.Campos.ViewModels;

namespace ParkNet_Ricardo.Campos.Pages.DriversLicense
{
    public class CreateModel : PageModel
    {
        private readonly IDriversLicenseService _driversLicenseService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IDriversLicenseService driversLicenseService, UserManager<ApplicationUser> userManager)
        {
            _driversLicenseService = driversLicenseService;
            _userManager = userManager;
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
            bool creationsuccessful = _driversLicenseService.Create(currentUser.Email, DriversLicense.ExpireDate, DriversLicense.LicenseNumber);
            if (creationsuccessful) return RedirectToPage("./BankCard");
            return RedirectToPage("./Index");
        }
    }
}
