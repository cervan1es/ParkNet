using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IBankCardService
    {
        List<BankCard> GetAllCustomerBankCards(string customerEmail);
        bool CreateBankCard(string customerEmail, string cardNumber, DateTime expireDate);
    }
}
