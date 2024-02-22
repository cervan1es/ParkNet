using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkNet_Ricardo.Campos.Interfaces;
using ParkNet_Ricardo.Campos.Repositories;
using System.Drawing.Text;

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
                var floor = await _floorRepository.AddAsyncFloor(park.ID, number);
            }

            List<string> rows = parkLayout.Split("\r\n").ToList();
            int maxRowLength = GetMaxRowLength(rows);
            int floorNumber= 0;

            var floorsEntities = await _floorRepository.GetAsyncAll();

            for (int i = 0; i < rows.Count(); i++)
            {
                char[] row = rows[i].ToCharArray();
                var floor = floorsEntities.FirstOrDefault(f => f.Number.Equals(floorNumber));
                for (int j = 0; j < maxRowLength; j++)
                {
                    char currentRow = GetRow(j);
                    string currentColumn = GetColumn(i);
                    char? currentVehicleType;
                    if (j < row.Count()) currentVehicleType = row[j];
                    else currentVehicleType = null;
                    await _parkingSpaceRepository.AddAsyncParkingSpace(floor.ID, currentRow, currentColumn, currentVehicleType);
                }
            }

            return true;
        }

        public char GetRow(int rowNumber)
        {
            if (rowNumber >= 26) return '\0';
            if (rowNumber < 0) return '\0';

            char[] alphabet =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            return alphabet[rowNumber];
        }

        public string GetColumn(int columnNumber)
        {
            if (columnNumber < 0) return "";
            if (columnNumber >= 52) return "";

             string[] alphabet =
                {
                    "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                    "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
                };

            if (columnNumber <= 25) return $"{columnNumber + 1}";
            return $"{alphabet[columnNumber]}";


        }
        
        private static bool CharactersValidation(string parkCharacters)
        {
            foreach(char character in parkCharacters)
            {
                if (character == ' ' || character == '\n' || character == 'C' || character == 'M')
                {
                    return true;
                }
            }
            return false;
          
        }

        private static List<string> FloorIdentification(string parkLayout)
        {
            var floors = parkLayout.Split("\r\n\r\n").ToList();
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
