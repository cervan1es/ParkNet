﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.ParkSetUp
{
    public class CreateModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;
        private readonly PARKNET.Services.ParkingSpaceService _parkingSpaceService;

        public CreateModel(PARKNET.Data.ApplicationDbContext context, Services.ParkingSpaceService parkingSpaceService)
        {
            _context = context;
            _parkingSpaceService = parkingSpaceService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Park Park { get; set; } = default!;



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Park.Add(Park);
            await _context.SaveChangesAsync();
            _parkingSpaceService.AddParkingSpacesByParkID(Park.ParkID, Park.Layout);

            return RedirectToPage("./Index");
        }
    }
}
