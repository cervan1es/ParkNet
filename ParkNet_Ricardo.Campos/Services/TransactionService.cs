using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerRepository _customerRepository;
        public TransactionService(ITransactionRepository transactionRepository, ICustomerRepository customerRepository)
        {
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
        }
        public async Task<bool> CreateTransactionAsync(string customerEmail, decimal transactionValue, DateTime transactionDate)
        {
            var customer = _customerRepository.GetByEmail(customerEmail);
           
            var createTransactionWithSuccess = await _transactionRepository.AddTransaction(customer.ID, transactionValue, transactionDate);
            if (createTransactionWithSuccess is null)
            {
                return false;
            }
            return true;
        }

        public async Task<decimal> GetBalanceByCustomerAsync(string customerEmail)
        {
            var customer = _customerRepository.GetByEmail(customerEmail);
            var transactions = await _transactionRepository.GetTransactions(customer.ID);
            decimal balance = 0;
            foreach (var transaction in transactions)
            {
                balance = balance + transaction.Value;
            }
            return balance;
        }

        public async Task<IList<Transaction>> GetTransactionsByCustomerAsync(string customerEmail)
        {
            var customer = _customerRepository.GetByEmail(customerEmail);
            var transactions = await _transactionRepository.GetTransactions(customer.ID);
            return transactions;
        }
    }
}
