using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IPermitRepository
    {
        List<Permit> GetPermitsByVehicleID(Guid vehicleID);
        Task<Permit> AddPermit(Guid vehicleID, Guid parkingSpaceID, DateTime startDate, DateTime endDate, decimal price, Guid permitTariff);

    }
}
