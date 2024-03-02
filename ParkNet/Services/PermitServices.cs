using PARKNET.Repositories;

namespace PARKNET.Services
{
    public class PermitService
    {
        public PermitRepository _permitRepository;
        public ParkingSpaceRepository _parkingSpaceRepository;
        public PermitService(PermitRepository permitRepository, ParkingSpaceRepository parkingSpaceRepository)
        {
            _permitRepository = permitRepository;
            _parkingSpaceRepository = parkingSpaceRepository;
        }

        public void UpdateNotOccupiedPermits()
        {
            var permits = _permitRepository.GetPermits();
            var parkingSpaces = _parkingSpaceRepository.GetAllParkingSpaces();

            foreach (var permit in permits)
            {
                if (permit.EndDate < DateTime.Now)
                {
                    var parkingSpace = parkingSpaces.FirstOrDefault(p => p.ParkingSpaceID == permit.ParkingSpaceID);
                    parkingSpace.IsOccupied = false;
                    _parkingSpaceRepository.UpdtateParkingSpace(parkingSpace);
                }
            }
        }
    }
}
