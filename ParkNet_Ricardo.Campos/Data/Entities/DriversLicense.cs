using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class DriversLicense
    {
        [Key]
        public Guid ID { get; private set; }
        [ForeignKey("Customer")]
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        public int LicenseNumber { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }

        public DriversLicense()
        {
            ID = Guid.NewGuid();
        }
    }
}
