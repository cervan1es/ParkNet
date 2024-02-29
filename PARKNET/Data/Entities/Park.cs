using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class Park
    {
        [Key]
        public Guid ParkID { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Layout { get; set; }


        public Park()
        {
            ParkID = Guid.NewGuid();
        }
    }
}
