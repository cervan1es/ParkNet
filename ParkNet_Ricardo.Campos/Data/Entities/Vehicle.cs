using System.ComponentModel.DataAnnotations;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Vehicle
    {
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public string Type { get; set; }
        public string Plate { get; set; }

        public Vehicle()
        {
            ID = Guid.NewGuid();
        }
    }
}
