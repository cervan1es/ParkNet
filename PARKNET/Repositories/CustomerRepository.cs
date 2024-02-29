using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Repositories
{
    public class CustomerRepository
    {
        public ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer GetCustomerbyEmail(string email)
        {
            return _context.Customer.FirstOrDefault(c => c.CustomerEmail.Equals(email));
        }
    }
}
