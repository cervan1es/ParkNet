using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Services
{
    public class PermitService : IPermitService
    {
        private readonly IPermitRepository _permitRepository;

        public PermitService(IPermitRepository permitRepository)
        {
            _permitRepository = permitRepository;
        }

        public async Task<Permit> AddPermit(Guid vehicleID, Guid parkingSpaceID, DateTime startDate, DateTime endDate, decimal price, Guid permitTariffID)
        {
            return await _permitRepository.AddPermit(vehicleID, parkingSpaceID, startDate, endDate, price, permitTariffID);
        }

        public List<Permit> GetPermitsByVehicleID(Guid vehicleID)
        {
            return _permitRepository.GetPermitsByVehicleID(vehicleID);
        }
    }
}
