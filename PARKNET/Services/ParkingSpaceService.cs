using PARKNET.Data.Entities;
using PARKNET.Repositories;

namespace PARKNET.Services
{
    public class ParkingSpaceService
    {
        public ParkingSpaceRepository _parkingSpaceRepository;

        public ParkingSpaceService(ParkingSpaceRepository parkingSpaceRepository)
        {
            _parkingSpaceRepository = parkingSpaceRepository;
        }


        // - função para receber a string e guardar em coordenadas na db
        public void AddParkingSpacesByParkID(Guid parkID, string layout)
        {
            List<string>rows = layout.Split("\r\n").ToList();

            int maxRowLength = rows.Max(m => m.Length);

            for (int i = 0; i < rows.Count; i++)
            {
                char[] row = rows[i].ToCharArray();

                for (int j = 0; j < maxRowLength; j++)
                {
                    string currentCoordinate = GetCoordinate(i,j);
                    char? currentVehicleType;

                    if (j < row.Count()) currentVehicleType = row[j];
                    else currentVehicleType = null;

                    var currentParkingSpace = new ParkingSpace
                    {
                        ParkId = parkID,
                        Coordinate = currentCoordinate,
                        VehicleType = currentVehicleType,
                        IsOccupied = false
                    };

                    _parkingSpaceRepository.AddParkingSpace(currentParkingSpace);
                }
            }
        }

        // lógica de conversão de coordenadas | row + column = coordinate
        public string GetCoordinate(int rowNumber, int columnNumber)
        {
            if (rowNumber >= 26) return null;
            if (rowNumber < 0) return null;
            if (columnNumber < 0) return null;
            if (columnNumber >= 52) return null;

            string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string row = alphabet[rowNumber];
            string column;

            if (columnNumber <= 25)
            {
                column = $"{columnNumber + 1}";
            }
            else
            {
                column = alphabet[columnNumber];
            }
            return $"{row}{column}";
        }


         // - função para ir buscar o layout com as coordenadas à db e printar
         public List<ParkingSpace> GetParkingSpacesByParkIdOrderedByCoordinate(Guid parkId)
        {
            return _parkingSpaceRepository.GetParkingSpacesByParkIdOrderedByCoordinate(parkId);
        }


         // - função para verificar se a coordenada está ocupada












            //private static bool CharactersValidation(string parkCharacters)
            //{
            //    foreach (char character in parkCharacters)
            //    {
            //        if (character == ' ' || character == '\n' || character == 'C' || character == 'M')
            //        {
            //            return true;
            //        }
            //    }
            //    return false;
            //}


            //public ParkingSpace AddParkingSpacesByParkID(Guid parkID, string layout)
            //{

            //    ParkingSpace parkingSpace = new ParkingSpace();
            //    parkingSpace.ParkId = parkID;
            //    parkingSpace.Coordinate = layout;
            //    parkingSpace.VehicleType = 'C';
            //    parkingSpace.IsOccupied = false;
            //    return _parkingSpaceRepository.AddParkingSpace(parkingSpace);
            //}
        }
}