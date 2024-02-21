using ParkNet_Ricardo.Campos.Interfaces;
using ParkNet_Ricardo.Campos.Repositories;

namespace ParkNet_Ricardo.Campos.Services
{
    public class ParkLayoutService
    {
        private IParkRepository _parkRepository;
        private IFloorRepository _floorRepository;
        private IParkingSpaceRepository _parkingSpaceRepository;
        public ParkLayoutService(IParkRepository parkRepository, IFloorRepository floorRepository, IParkingSpaceRepository parkingSpaceRepository)
        {
            _parkRepository = parkRepository;
            _floorRepository = floorRepository;
            _parkingSpaceRepository = parkingSpaceRepository;
        }
        public async Task<bool> AddPark(string name, string parkLayout)
        {
            bool characterCheck = CharactersValidation(parkLayout);


            if (characterCheck == false)
            {
                return false;
            }
            var park = await _parkRepository.AddAsyncPark(name, parkLayout);

            List<string> floors = FloorIdentification(parkLayout);
            foreach (var floorLayout in floors)
            {
                int floorNumber = floors.IndexOf(floorLayout);
                await _floorRepository.AddAsyncFloor(park.ID, floorNumber, floorLayout);
            }
            
            return true;
        }
        private static bool CharactersValidation(string parkCharacters)
        {
            for (int i = 0; i < parkCharacters.Length; i++)
            {
                if (parkCharacters[i] != 'C' || parkCharacters[i] != 'M' || parkCharacters[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private static List<string> FloorIdentification(string parkLayout)
        {
            var floors = parkLayout.Split("\n\n").ToList();
            return floors;
        }

        private static int GetMaxRowLength(string floor)
        {
            var rows = floor.Split("\n").ToList();
            var maxRowLength = 0;
            foreach (var row in rows)
            {
                if (row.Length > maxRowLength)
                {
                    maxRowLength = row.Length;
                }
            }
            return maxRowLength;
        }
        


    }
}
