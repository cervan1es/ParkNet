using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Repositories
{
    public class ParkingSpaceRepository
    {
        public readonly ApplicationDbContext _context;

        public ParkingSpaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ParkingSpace AddParkingSpace(ParkingSpace parkingSpace)
        {
            _context.ParkingSpace.Add(parkingSpace);
            _context.SaveChanges();
            return parkingSpace;
        }

        public List<ParkingSpace> GetParkingSpacesByParkIdOrderedByCoordinate(Guid parkID)
        {
            return _context.ParkingSpace.Where(p => p.ParkId == parkID).OrderBy(p => p.Coordinate).ToList();
        }
    }
}
