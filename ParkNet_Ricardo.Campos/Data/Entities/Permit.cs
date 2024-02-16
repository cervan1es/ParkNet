using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Permit
    {
        [Key]   
        public Guid ID { get; private set; }
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
        [DateGreaterThanToday(ErrorMessage = "Start date must be the same or greater than today")]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public Permit()
        {
            ID = Guid.NewGuid();
        }
    }

    public class DateGreaterThanTodayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date >= DateTime.Today;
        }
    }
}
