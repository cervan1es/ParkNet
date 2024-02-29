using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; private set; }

        [ForeignKey("Customer")]
        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;


        public Transaction()
        {
            TransactionID = Guid.NewGuid();
        }
    }
}
