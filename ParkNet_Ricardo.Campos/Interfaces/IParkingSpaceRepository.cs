using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IParkingSpaceRepository
    {
        Task<ParkingSpace> AddAsyncParkingSpace(Guid floorID, char row, string column, char? vehicleType);
    }
}
