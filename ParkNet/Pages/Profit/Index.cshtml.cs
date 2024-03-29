﻿using System;
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
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public List<ParkingSpace> ParkingSpaces { get; set; } = new List<ParkingSpace>();
        public List<Data.Entities.PermitTariff> PermitTariffs { get; set; } = new List<Data.Entities.PermitTariff>();
        public List<Park> Parks { get; set; } = new List<Park>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public async Task OnGetAsync()
        {
            Permit = await _context.Permit.ToListAsync();
            Profit = Permit.Sum(p => p.Price);
            Vehicles = await _context.CustomerVehicle.ToListAsync();
            ParkingSpaces = await _context.ParkingSpace.ToListAsync();
            PermitTariffs = await _context.PermitTariff.ToListAsync();
            Parks = await _context.Park.ToListAsync();
            Customers = await _context.Customer.ToListAsync();
        }
    }
}
