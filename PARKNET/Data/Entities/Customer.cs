using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PARKNET.Data.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerID { get; private set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public int DriversLicenseNumber { get; set; }

        [Required]
        public DateTime DriversLicenseExpireDate { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public bool IsAdmin { get; set; }


        public Customer()
        {
            CustomerID = Guid.NewGuid();
        }
    }
}
