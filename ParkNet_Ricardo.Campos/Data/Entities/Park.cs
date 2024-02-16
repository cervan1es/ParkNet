using System.ComponentModel.DataAnnotations;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Park
    {
        [Key]
        public Guid ID { get; private set; }
        [Required]
        public string Name { get; set; }

        public Park()
        {
            ID = Guid.NewGuid();
        }
    }
}
