using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Services
{
    public class DriversLicenseService : IDriversLicenseService
    {
        private IDriversLicenseRepository _driversLicenseRepository;
        public DriversLicenseService(IDriversLicenseRepository driversLicenseRepository)
        {
            _driversLicenseRepository = driversLicenseRepository;
        }
        public bool Create(string customerEmail, DateTime expireDate, int licenseNumber)
        {
            _driversLicenseRepository.Create(customerID, expireDate, licenseNumber);
        }
    }
}
