using PARKNET.Data.Entities;
using PARKNET.Repositories;

namespace PARKNET.Services
{
    public class TransactionService
    {
        private readonly Repositories.TransactionRepository _transactionRepository;
        private readonly CustomerRepository _customerRepository;

        public TransactionService(TransactionRepository transactionRepository, CustomerRepository customerRepository)
        {
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
        }


        public decimal GetBalance()
        {
            return _transactionRepository.GetTransactions().Sum(t => t.Value);
        }


        public bool AddTransaction(string customerEmail, decimal value)
        {
            var customer = _customerRepository.GetCustomerbyEmail(customerEmail);
            var balance = _transactionRepository.GetBalance(customer.CustomerID);
            if (balance <= 0) return false;

            var transaction = new Transaction
            {
                CustomerID = customer.CustomerID,
                Value = value,
                Date = DateTime.Now
            };
            _transactionRepository.AddTransaction(transaction);
            return true;
        }


    }
}
