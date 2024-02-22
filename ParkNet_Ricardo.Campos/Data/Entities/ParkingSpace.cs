using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class ParkingSpace
    {
        [Key]
        public Guid ID { get; private set; }
        [ForeignKey("Floor")]
        public Guid FloorID { get; set; }
        [Required]
        public char Row { get; set; }
        [Required]
        public string Column { get; set; }

        public char? VehicleType { get; set; }

        public ParkingSpace()
        {
            ID = Guid.NewGuid();
        }
    }
} 
