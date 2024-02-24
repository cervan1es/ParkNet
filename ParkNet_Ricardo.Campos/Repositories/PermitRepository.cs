using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class PermitRepository : IPermitRepository
    {
        private readonly ApplicationDbContext _context;

        public PermitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Permit> AddPermit(Guid vehicleID, Guid parkingSpaceID, DateTime startDate, DateTime endDate, decimal price, Guid permitTariffID)
        {
            var permit = new Permit
            {
                VehicleID = vehicleID,
                ParkingSpaceID = parkingSpaceID,
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                PermitTariffID = permitTariffID
            };
            await _context.Permit.AddAsync(permit);
            await _context.SaveChangesAsync();
            return permit;
        }

        public List<Permit> GetPermitsByVehicleID(Guid vehicleID)
        {
            var permits = _context.Permit.Where(p => p.VehicleID == vehicleID).ToList();
            return permits;
        }
    }
}
