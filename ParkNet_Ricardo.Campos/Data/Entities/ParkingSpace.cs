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
        public string Coordenate { get; set; }

        public char? VehicleType { get; set; }

        public ParkingSpace()
        {
            ID = Guid.NewGuid();
        }
    }
}
