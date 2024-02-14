namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Permit
    {
        public Guid ID { get; private set; }
        public Guid VehicleID { get; set; }
        public Guid ParkingSpaceID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public Permit()
        {
            ID = Guid.NewGuid();
        }
    }
}
