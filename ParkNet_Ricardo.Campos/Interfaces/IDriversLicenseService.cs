namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IDriversLicenseService
    {
        bool Create(string customerEmail, DateTime expireDate, int licenseNumber);
    }
}
