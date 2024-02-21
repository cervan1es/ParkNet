using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IParkRepository
    {
        Task<Park> AddAsyncPark(string parkName, string parkLayout);
    }
}
