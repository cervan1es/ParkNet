using Microsoft.EntityFrameworkCore;
using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> AddTransaction(Guid customerID, decimal transactionValue, DateTime transactionDate)
        {
            var transaction = new Transaction
            {
                CustomerID = customerID,
                Value = transactionValue,
                Date = transactionDate
            };

            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<List<Transaction>> GetTransactions(Guid customerID)
        {
            var transactions = await _context.Transaction.ToListAsync();
            return transactions.FindAll(t => t.CustomerID.Equals(customerID));
        }
    }
}