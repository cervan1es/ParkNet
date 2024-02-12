namespace ParkNet_Ricardo.Campos.Entities
{
    public class Ticket
    {
        public Guid ID { get; private set; }
        public Guid VehicleID { get; set; }
        public Guid ParkingSpaceID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TicketlPrice { get; set; }

        public Ticket ()
        {
            ID = Guid.NewGuid();
        }
    }
}
