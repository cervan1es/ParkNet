namespace ParkNet_Ricardo.Campos.Entities
{
    public class Permit
    {
        public int PermitID { get; set; }
        public required int VehicleID { get; set; }

        public required int ParkingSpaceID { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PermitPrice { get; set; }

    }
}
