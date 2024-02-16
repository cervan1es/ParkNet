using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class PermitTariff
    {
        [Key]
        public Guid ID { get; private set; }
        [Required]
        [ForeignKey("Vehicle")]
        public Guid VehicleID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }

        public PermitTariff()
        {
            ID = Guid.NewGuid();
        }
    }
}
