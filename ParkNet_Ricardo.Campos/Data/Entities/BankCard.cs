namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class BankCard
    {
        public Guid ID { get; private set; }
        public Guid CustomerID { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }

        public BankCard()
        {
            ID = Guid.NewGuid();
        }
    }
}
