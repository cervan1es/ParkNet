using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class CustomerVehicle
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey("Customer")]
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        public char VehicleType { get; set; }
        [Required]
        public string Plate { get; set; }

        public CustomerVehicle()
        {
            ID = Guid.NewGuid();
        }
    }
}
