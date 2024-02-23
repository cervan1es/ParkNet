using ParkNet_Ricardo.Campos.Data.Migrations;
using ParkNet_Ricardo.Campos.Interfaces;
using SQLitePCL;

namespace ParkNet_Ricardo.Campos.Services
{
    public class DriversLicenseService : IDriversLicenseService
    {
        private IDriversLicenseRepository _driversLicenseRepository;
        private ICustomerRepository _customerRepository;
        public DriversLicenseService(IDriversLicenseRepository driversLicenseRepository, ICustomerRepository customerRepository)
        {
            _driversLicenseRepository = driversLicenseRepository;
            _customerRepository = customerRepository;
        }
        public bool Create(string customerEmail, DateTime expireDate, int licenseNumber)
        {
            if (expireDate < DateTime.Now) return false;

            var customer = _customerRepository.GetByEmail(customerEmail);
            var driversLicense = _driversLicenseRepository.Create(customer!.ID, expireDate, licenseNumber);

            return true;
        }
    }
}
