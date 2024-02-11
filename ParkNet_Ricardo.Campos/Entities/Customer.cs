using System.Runtime.CompilerServices;

namespace ParkNet_Ricardo.Campos.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public required string CustomerName { get; set; }

       // [String]
        public required string DriversLicense { get; set; }

        public required string BankCard { get; set; }

        public required string Email { get; set; }

        public required decimal Balance { get; set; }
    }
}
