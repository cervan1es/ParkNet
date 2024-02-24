using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IPermitService
    {
        Task<Permit> AddPermit(Guid vehicleID, Guid parkingSpaceID, DateTime startDate, DateTime endDate, decimal price, Guid permitTariffID);
        List<Permit> GetPermitsByVehicleID(Guid vehicleID);
    }
}
