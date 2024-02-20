using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class ParkingSpaceRepository (ApplicationDbContext context)
    {
        private ApplicationDbContext _context = context;
        public async Task<ParkingSpace> AddParkingSpace(Guid floorID, string parkingSpaceCoordenate, char vehicleType)
        {
           var parkingSpace = new ParkingSpace
           {
               FloorID = floorID,
               Coordenate = parkingSpaceCoordenate,
               VehicleType = vehicleType
           };
            _context.ParkingSpace.Add(parkingSpace);
            await _context.SaveChangesAsync();
            return parkingSpace;
        }
    }
}
