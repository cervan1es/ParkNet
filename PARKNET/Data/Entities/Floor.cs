using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class Floor
    {
        [Key]
        public Guid FloorID { get; set; }

        [Required]
        [ForeignKey("Park")]
        public Guid ParkID { get; set; }

        [Required]
        public int Number { get; set; }


        public Floor()
        {
            FloorID = Guid.NewGuid();
        }
    }
}
