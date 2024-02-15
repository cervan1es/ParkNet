namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class DriversLicense
    {
        public Guid ID { get; private set; }
        public Guid CustomerID { get; set; }
        public int LicenseNumber { get; set; }
        public DateTime ExpireDate { get; set; }

        public DriversLicense()
        {
            ID = Guid.NewGuid();
        }
    }
}
