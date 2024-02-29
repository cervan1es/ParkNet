using PARKNET.Data.Entities;
using PARKNET.Repositories;

namespace PARKNET.Services
{
    public class ParkingSpaceService
    {
        public ParkingSpaceRepository _parkingSpaceRepository;

        public ParkingSpaceService(ParkingSpaceRepository parkingSpaceRepository)
        {
            _parkingSpaceRepository = parkingSpaceRepository;
        }

        public ParkingSpace AddParkingSpacesByParkID(Guid parkID, string layout)
        {

            ParkingSpace parkingSpace = new ParkingSpace();
            parkingSpace.ParkId = parkID;
            parkingSpace.Coordinate = layout;
            parkingSpace.VehicleType = 'C';
            parkingSpace.IsOccupied = false;
            return _parkingSpaceRepository.AddParkingSpace(parkingSpace);
        }
    }
}