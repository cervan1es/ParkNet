using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface ITransactionService
    {
        Task<bool> CreateTransactionAsync(string customerEmail, decimal transactionValue, DateTime transactionDate);
        Task<decimal> GetBalanceByCustomerAsync(string customerEmail);
        Task<IList<Transaction>> GetTransactionsByCustomerAsync(string customerEmail);

    }
}
