using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Repositories
{
    public class ParkingSpaceRepository
    {
        public ApplicationDbContext _context;
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
        public ParkingSpace GetParkingSpacebyId(int id)
        {
            return _context.ParkingSpace.Find(id);
        }
    }
}
