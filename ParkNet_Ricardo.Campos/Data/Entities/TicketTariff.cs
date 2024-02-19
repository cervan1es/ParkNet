using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class TicketTariff
    {
        [Key]
        public Guid ID { get; private set; }
        [ForeignKey("Vehicle")]
        [Required]
        public Guid VehicleID { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public decimal LevelPricePerMinute { get; set; }
        [Required]
        public int StartMinute { get; set; }
        [Required]
        public int EndMinute { get; set; }

        public TicketTariff()
        {
            ID = Guid.NewGuid();
        }
    }
}
