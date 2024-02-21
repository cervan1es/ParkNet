namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IParkingLayoutService
    {
        Task<bool> AddPark(string name, string parkLayout);
    }
}
