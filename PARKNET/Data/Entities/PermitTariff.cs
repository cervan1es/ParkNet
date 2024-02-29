using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class PermitTariff
    {
        [Key]
        public Guid PermitTariffID { get; private set; }

        [Required]
        public char VehicleType { get; set; }

        [Required]
        public string TariffType { get; set; }

        [Required]
        public decimal Price { get; set; }


        public PermitTariff()
        {
            PermitTariffID = Guid.NewGuid();
        }
    }
}
