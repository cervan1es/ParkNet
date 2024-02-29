using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleID { get; set; }

        [ForeignKey("Customer")]
        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public char VehicleType { get; set; }

        [Required]
        public string Plate { get; set; }


        public Vehicle()
        {
            VehicleID = Guid.NewGuid();
        }
    }
}
