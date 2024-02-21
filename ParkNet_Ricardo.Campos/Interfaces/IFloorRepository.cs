using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IFloorRepository
    {
        Task<Floor> AddAsyncFloor(Guid parkID, int floorNumber, string floorLayout);
        Task<List<Floor>> GetAsyncAll();
    }
}
