using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Customer
    {
        [Key]
        public Guid ID { get; private set; }
        public string? Name { get; set; }
        [Required]
        public string Email { get; set; }

        public Customer()
        {
            ID = Guid.NewGuid();
        }


    }
}
