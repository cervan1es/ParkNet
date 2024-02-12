namespace ParkNet_Ricardo.Campos.Entities
{
    public class Transaction
    {
        public Guid ID { get; private set; }
        public Guid CustomerID { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

        public Transaction()
        {
            ID = Guid.NewGuid();
        }
    }
}
