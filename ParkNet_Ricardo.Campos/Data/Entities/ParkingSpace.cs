namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class ParkingSpace
    {
        public Guid ID { get; private set; }
        public Guid FloorID { get; set; }
        public string Name { get; set; }

        public ParkingSpace()
        {
            ID = Guid.NewGuid();
        }
    }
}
