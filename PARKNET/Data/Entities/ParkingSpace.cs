using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class ParkingSpace
    {
        [Key]
        public Guid ParkingSpaceID { get; private set; }

        [ForeignKey("Floor")]
        public Guid FloorID { get; set; }

        [Required]
        public char Row { get; set; }

        [Required]
        public string Column { get; set; }

        [Required]
        public char? VehicleType { get; set; }

        [Required]
        public bool IsOccupied { get; set; }


        public ParkingSpace()
        {
            ParkingSpaceID = Guid.NewGuid();
        }
    }
}
