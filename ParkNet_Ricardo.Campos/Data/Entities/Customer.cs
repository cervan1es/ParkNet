namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public enum Roles
    {
        Admin = 1,
        User = 0
    }
    public class Customer
    {
        public Guid ID { get; private set; }
        public string? Name { get; set; }
        public string DriversLicense { get; set; }
        public string BankCard { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public Roles Role { get; set; }
        public Customer()
        {
            ID = Guid.NewGuid();
        }


    }
}
