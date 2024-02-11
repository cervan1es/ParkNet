namespace ParkNet_Ricardo.Campos.Entities
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public required string CustomerID { get; set; }
        public required string Type { get; set; }
        public required string Plate { get; set; }       
    }
}
