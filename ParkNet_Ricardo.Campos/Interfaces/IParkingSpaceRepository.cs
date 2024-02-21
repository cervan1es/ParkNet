using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IParkingSpaceRepository
    {
        Task<ParkingSpace> AddAsyncParkingSpace(Guid floorID, string parkingSpaceCoordenate, char vehicleType);
    }
}
