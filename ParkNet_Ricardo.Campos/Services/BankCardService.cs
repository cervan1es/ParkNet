using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Services
{
    public class BankCardService : IBankCardService
    {
        private IBankCardRepository _bankCardRepository;
        private ICustomerRepository _customerRepository;

        public BankCardService(IBankCardRepository bankCardRepository, ICustomerRepository customerRepository)
        {
            _bankCardRepository = bankCardRepository;
            _customerRepository = customerRepository;
        }

        public bool CreateBankCard(string customerEmail, string cardNumber, DateTime expireDate)
        {
            var customer = _customerRepository.GetByEmail(customerEmail);
            var bankCard = _bankCardRepository.Create(customer.ID, cardNumber, expireDate);

            if(bankCard is null) return false;
            else return true;
        }

        public List<BankCard> GetAllCustomerBankCards(string customerEmail)
        {
            var customer = _customerRepository.GetByEmail(customerEmail);
            var customerBankCards = _bankCardRepository.GetAllCustomerBankCards(customer.ID);

            return customerBankCards;
        }

    }
}
