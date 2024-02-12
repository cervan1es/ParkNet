namespace ParkNet_Ricardo.Campos.Entities
{
    public class Floor
    {
        public Guid ID { get; private set; }
        public Guid ParkID { get; set; }
        public int Number { get; set; }

        public Floor() 
        {
            ID = Guid.NewGuid();
        }
    }
}
