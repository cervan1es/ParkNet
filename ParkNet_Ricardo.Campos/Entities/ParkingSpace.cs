namespace ParkNet_Ricardo.Campos.Entities
{
    public class ParkingSpace
    {
        public int ParkingSpaceID { get; set; }
        public required int FloorID { get; set; }
        public required string ParkingSpaceName { get; set; }
    }
}
