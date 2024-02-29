using PARKNET.Data.Entities;
using PARKNET.Repositories;

namespace PARKNET.Services
{
    public class TransactionService
    {
        private readonly Repositories.TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public decimal GetBalance()
        {
            return _transactionRepository.GetTransactions().Sum(t => t.Value);
        }
    }
}
