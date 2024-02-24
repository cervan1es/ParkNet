using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactions(Guid customerID);
        Task<Transaction> AddTransaction(Guid customerID, decimal transactionValue, DateTime transactionDate);

    }
}
