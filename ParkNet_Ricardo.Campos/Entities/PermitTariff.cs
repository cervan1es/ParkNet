namespace ParkNet_Ricardo.Campos.Entities
{
    public class PermitTariff
    {
        public required int PermitTariffID { get; set; }
        public required string TariffPermitVehicle { get; set; }

        public required decimal PermitTariffType { get; set; }

        public required decimal PermitTariffPrice { get; set; }
    }
}