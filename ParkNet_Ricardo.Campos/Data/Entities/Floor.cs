using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Floor
    {
        [Key]
        public Guid ID { get; private set; }
        [Required]
        [ForeignKey("Park")]
        public Guid ParkID { get; set; }
        [Required]
        [Range(-99, 99, ErrorMessage="Range of floors goes from -99 to 99")]
        public int Number { get; set; }
        [Required]
        public string Layout { get; set; }

        public Floor()
        {
            ID = Guid.NewGuid();
        }
    }
}
