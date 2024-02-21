using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Pages.ParkSetUp
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet_Ricardo.Campos.Data.ApplicationDbContext _context;
        private readonly ParkNet_Ricardo.Campos.Interfaces.IParkingLayoutService _parkLayoutService;  

        public CreateModel(ParkNet_Ricardo.Campos.Data.ApplicationDbContext context, 
            Interfaces.IParkingLayoutService parkingLayoutService)
        {
            _context = context;
            _parkLayoutService = parkingLayoutService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Park Park { get; set; } = default!;
        [BindProperty]
        public string Layout { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            await _parkLayoutService.AddPark(Park.Name, Layout);
            
            return RedirectToPage("./Index");
        }
    }
}
