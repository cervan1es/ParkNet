namespace PARKNET.Data.Entities
{
    public class PermitPurchase
    {
        public Guid ID { get; private set; }
        public Guid VehicleID { get; set; }
        public Guid PermitTariffID { get; set; }
        public Guid ParkID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PermitPurchase()
        {
            ID = Guid.NewGuid();
        }
    }
}
