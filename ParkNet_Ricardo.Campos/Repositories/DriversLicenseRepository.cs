using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class DriversLicenseRepository : IDriversLicenseRepository
    {
        private readonly ApplicationDbContext _context;

        public DriversLicenseRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public DriversLicense Create(Guid customerID, DateTime expireDate, int licenseNumber)
        {
            var driversLicense = new DriversLicense
            {
                CustomerID = customerID,
                ExpireDate = expireDate,
                LicenseNumber = licenseNumber   
            };
            _context.DriversLicense.Add(driversLicense);
            _context.SaveChanges();
            return driversLicense;
        }
    }
}
