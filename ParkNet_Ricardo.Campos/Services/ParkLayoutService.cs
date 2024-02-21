using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkNet_Ricardo.Campos.Interfaces;
using ParkNet_Ricardo.Campos.Repositories;

namespace ParkNet_Ricardo.Campos.Services
{
    public class ParkLayoutService : IParkingLayoutService
    {
        private IParkRepository _parkRepository;
        private IFloorRepository _floorRepository;
        private IParkingSpaceRepository _parkingSpaceRepository;
        public ParkLayoutService(IParkRepository parkRepository, 
            IFloorRepository floorRepository, 
            IParkingSpaceRepository parkingSpaceRepository)
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
                int number = floors.IndexOf(floorLayout);
                var floor = await _floorRepository.AddAsyncFloor(park.ID, number, floorLayout);
            }

            List<string> rows = parkLayout.Split("\n").ToList();
            int maxRowLength = GetMaxRowLength(rows);
            int floorNumber= 0;

            var floorsEntities = await _floorRepository.GetAsyncAll();

            for (int i = 0; i < rows.Count(); i++)
            {
                List<string> row = rows[i].Split("").ToList();
                var floor = floorsEntities[floorNumber];
                if (row.Count() == 0) floorNumber = floorNumber + 1;
                for (int j = 0; j < maxRowLength; j++)
                {
                    await _parkingSpaceRepository.AddAsyncParkingSpace(floor.ID, GetCoordinates(j, i), char.Parse(row[j]));
                }
            }

            return true;
        }

        private static string GetCoordinates(int column, int row)
        {
            if (column >= 26) return "";
            if (column < 0) return "";
            if (row < 0) return "";
            if (row >= 52) return "";

            string[] alphabet = [
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            ];

            if (row <= 25) return $"{alphabet[column][row + 1]}";
            return $"{alphabet[column]}{alphabet[row]}";
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

        private static int GetMaxRowLength(List<string> rows)
        {
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
