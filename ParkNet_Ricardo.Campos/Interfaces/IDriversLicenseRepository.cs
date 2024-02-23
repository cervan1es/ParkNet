using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IDriversLicenseRepository
    {
        DriversLicense Create(Guid customerID, DateTime expireDate, int licenseNumber);
    }
}
