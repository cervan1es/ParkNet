using System.ComponentModel.DataAnnotations;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Vehicle
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Type { get; set; }

        public Vehicle()
        {
            ID = Guid.NewGuid();
        }
    }
}
