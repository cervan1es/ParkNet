using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Transaction
    {
        [Key]
        public Guid ID { get; private set; }
        [ForeignKey("Customer")]
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        public Transaction()
        {
            ID = Guid.NewGuid();
        }
    }
}
