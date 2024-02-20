using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class ParkRepository(ApplicationDbContext context) : IParkRepository
    {
        private ApplicationDbContext _context = context;

        public async Task<Park> AddAsyncPark (string parkName, string parkLayout)
        {
            var park = new Park
            {
                Name = parkName,
                Layout = parkLayout
            };
            _context.Park.Add(park);
            await _context.SaveChangesAsync();
            return park;
        }
    }
}
