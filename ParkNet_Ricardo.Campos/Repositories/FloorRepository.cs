using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class FloorRepository(ApplicationDbContext context) : IFloorRepository
    {
        private ApplicationDbContext _context = context;

        public async Task<Floor> AddAsyncFloor(Guid parkID, int floorNumber)
        {
            var floor = new Floor
            {
                ParkID = parkID,
                Number = floorNumber
            };
            _context.Floor.Add(floor);
            await _context.SaveChangesAsync();
            return floor;
        }

        public async Task<List<Floor>> GetAsyncAll()
        {
            return await _context.Floor.ToListAsync();
        }
    }
}
