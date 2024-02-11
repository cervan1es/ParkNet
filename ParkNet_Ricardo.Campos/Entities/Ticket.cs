namespace ParkNet_Ricardo.Campos.Entities
{
    public class Ticket
    {
        public required int TicketID { get; set; }
        public required int VehicleID { get; set; }
        public required int ParkingSpaceID { get; set; }

        public required DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TicketlPrice { get; set; }
    }
}
