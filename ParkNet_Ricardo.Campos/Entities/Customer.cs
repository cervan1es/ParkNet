using System.Runtime.CompilerServices;

namespace ParkNet_Ricardo.Campos.Entities
{
    public class Customer
    {
        public Guid ID { get; private set; }
        public string? Name { get; set; }
        public string DriversLicense { get; set; }
        public string BankCard { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public Customer()
        {
            ID = Guid.NewGuid();
        }
        

    }
}
