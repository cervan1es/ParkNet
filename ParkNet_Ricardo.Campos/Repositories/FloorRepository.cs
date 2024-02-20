using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class FloorRepository(ApplicationDbContext context)
    {
        private ApplicationDbContext _context = context;

        public async Task<Floor> AddAsyncFloor(Guid parkID, int floorNumber, string floorLayout)
        {
            var floor = new Floor
            {
                ParkID = parkID,
                Number = floorNumber,
                Layout = floorLayout
            };
            _context.Floor.Add(floor);
            await _context.SaveChangesAsync();
            return floor;
        }
    }
}
