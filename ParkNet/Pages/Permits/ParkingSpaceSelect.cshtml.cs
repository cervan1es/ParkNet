using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.Permits
{
    public class ParkingSpaceSelectModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public ParkingSpaceSelectModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Permit Permit { get; set; } = new();

        public IActionResult OnGet()
        {
            var permitPurchase = _context.PermitPurchase.ToList()[0];
            var vehicleType = _context.CustomerVehicle.Find(permitPurchase.VehicleID).VehicleType;

            var park = _context.Park.Find(permitPurchase.ParkID);
            MaxRowLength = park.Layout.Split("\r\n").ToList().Max(m => m.Length);

            var selectItems = _context.ParkingSpace
                .Where(ps => ps.ParkID == permitPurchase.ParkID
                && ps.IsOccupied == false
                && ps.VehicleType == vehicleType).OrderBy(ps=>ps.Coordinate).ToList();
            ViewData["ParkingSpaces"] = new SelectList(selectItems, "ParkingSpaceID" , "Coordinate");


            ParkLayoutRows = park.Layout.Split("\r\n").ToList();
            Permit.VehicleID = permitPurchase.VehicleID;
            Permit.PermitTariffID = permitPurchase.PermitTariffID;
            Permit.StartDate = permitPurchase.StartDate;
            Permit.EndDate = permitPurchase.EndDate;
            Permit.Price = permitPurchase.Price;

            return Page();
        }


        [BindProperty]
        public List<string> ParkLayoutRows { get; set; } = default!;

        [BindProperty]
        public int MaxRowLength { get; set; } = 0;

        [BindProperty]
        public List<string> Alphabet { get; set; } = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}; 

        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var permitPurchase = _context.PermitPurchase.ToList()[0];

            Permit.VehicleID = permitPurchase.VehicleID;
            Permit.PermitTariffID = permitPurchase.PermitTariffID;
            Permit.StartDate = permitPurchase.StartDate;
            Permit.EndDate = permitPurchase.EndDate;
            Permit.Price = permitPurchase.Price;

            var currentParkingSpace = _context.ParkingSpace.Find(Permit.ParkingSpaceID);
            currentParkingSpace.IsOccupied = true;
            _context.ParkingSpace.Update(currentParkingSpace);
            _context.SaveChanges();

            _context.Permit.Add(Permit);
            await _context.SaveChangesAsync();
            _context.PermitPurchase.ExecuteDelete();
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
