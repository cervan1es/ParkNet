using PARKNET.Data.Entities;
using PARKNET.Repositories;

namespace PARKNET.Services
{
    public class CustomerService
    {
        public CustomerRepository _customerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(string email)
        {
            if (email is null) return null;
            var customer = new Customer
            {
                CustomerEmail = email
            };
            return _customerRepository.AddCustomer(customer); 
        }

        public Customer GetCustomerbyEmail(string email)
        {
            return _customerRepository.GetCustomerbyEmail(email);
        }
    }
}
