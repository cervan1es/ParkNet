namespace ParkNet_Ricardo.Campos
{
    public class TariffTicket
    {
        public required int TariffTicketID { get; set; }
        public required string TariffTicketVehicle { get; set; }

        public required decimal TariffTicketLevel { get; set; }

        public required decimal TariffStart { get; set; }
        public required decimal TariffEnd { get; set; }

        public required decimal LevelPricePerMinute { get; set; }
    }
}
