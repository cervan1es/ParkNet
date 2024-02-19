namespace ParkNet_Ricardo.Campos.Services
{
    public class ParkLayout
    {

        public void AddPark()
        {
            // verificar se tem nome - se nao tiver erro
            // adicionar a entidade parque na tabela
            // verificar se os caracteres sao C, M ou espaco
            // identificar os diferentes floors
            // atribuir os floors aos respectivos 
            // verificar o tamanha da linha maior
            // adicionar o parking space
        }
        private bool CharactersValidation(string parkCharacters)
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

        private List<string> FloorIentification(string parkLayout)
        {
            var floors = parkLayout.Split("\n\n").ToList();
            return floors;
        }

        private int GetMaxRowLength(string floor)
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
