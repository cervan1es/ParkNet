using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? GetByEmail(string email);
    }
}
