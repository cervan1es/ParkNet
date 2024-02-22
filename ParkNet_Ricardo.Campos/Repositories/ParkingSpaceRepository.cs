using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class ParkingSpaceRepository (ApplicationDbContext context) : IParkingSpaceRepository
    {
        private ApplicationDbContext _context = context;
        public async Task<ParkingSpace> AddAsyncParkingSpace(Guid floorID, char row, string column, char? vehicleType)
        {
           var parkingSpace = new ParkingSpace
           {
               FloorID = floorID,
               Row = row,
               Column = column,
               VehicleType = vehicleType
           };
            _context.ParkingSpace.Add(parkingSpace);
            await _context.SaveChangesAsync();
            return parkingSpace;
        }
    }
}
