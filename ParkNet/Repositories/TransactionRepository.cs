using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Repositories
{
    public class TransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Transaction> GetTransactions()
        {
            return _context.Transaction.ToList();
        }


        public void AddTransaction(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
        }


        public decimal GetBalance(Guid customerID)
        {
            var customerTransactions = _context.Transaction.Where(t => t.CustomerID == customerID);
            return customerTransactions.Sum(t => t.Value);
        }
    }
}
