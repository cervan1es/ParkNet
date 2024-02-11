namespace ParkNet_Ricardo.Campos.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public required int CustomerID { get; set; }
        public required decimal Value { get; set; }
        public required DateTime TransactionDateTime { get; set; }
    }
}
