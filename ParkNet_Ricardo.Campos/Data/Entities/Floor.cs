using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Floor
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [ForeignKey("Park")]
        public Guid ParkID { get; set; }
        [Required]
        public int Number { get; set; }

        public Floor()
        {
            ID = Guid.NewGuid();
        }
    }
}
