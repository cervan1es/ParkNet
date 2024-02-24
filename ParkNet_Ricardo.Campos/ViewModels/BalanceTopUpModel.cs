using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.ViewModels
{
    public class BalanceTopUpModel
    {
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
        public List<BankCard> BankCards { get; set; }
    }
}
