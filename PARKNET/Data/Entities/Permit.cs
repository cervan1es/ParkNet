using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class Permit
    {
        [Key]
        public Guid PermitID { get; private set; }

        [Required]
        [ForeignKey("Vehicle")]
        public Guid VehicleID { get; set; }

        [Required]
        [ForeignKey("ParkingSpace")]
        public Guid ParkingSpaceID { get; set; }

        [Required]
        [ForeignKey("PermitTariff")]
        public Guid PermitTariffID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }


        public Permit()
        {
            PermitID = Guid.NewGuid();
        }
    }
}
