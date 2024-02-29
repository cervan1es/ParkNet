using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly PARKNET.Data.ApplicationDbContext _context;

        public IndexModel(PARKNET.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicle = await _context.CustomerVehicle.ToListAsync();
        }
    }
}
