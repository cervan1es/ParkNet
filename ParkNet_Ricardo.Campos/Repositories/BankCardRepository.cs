using ParkNet_Ricardo.Campos.Data;
using ParkNet_Ricardo.Campos.Data.Entities;
using ParkNet_Ricardo.Campos.Interfaces;

namespace ParkNet_Ricardo.Campos.Repositories
{
    public class BankCardRepository : IBankCardRepository
    {
        private readonly ApplicationDbContext _context;
        public BankCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BankCard Create(Guid customerID, string cardNumber, DateTime expireDate)
        {
            var bankCard = new BankCard
            {
                CustomerID = customerID,
                CardNumber = cardNumber,
                ExpireDate = expireDate
            };
            _context.BankCard.Add(bankCard);
            _context.SaveChanges();
            return bankCard;
        }

        public List<BankCard> GetAllCustomerBankCards(Guid Customer)
        {
            return _context.BankCard.ToList();
        }
    }
}
