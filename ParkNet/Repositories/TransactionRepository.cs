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
    }
}
