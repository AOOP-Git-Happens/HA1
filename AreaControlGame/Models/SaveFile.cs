using System;
using System.IO;
using System.Text;

namespace AreaControlGame.Models;

public static class SaveFile
{
    public static void SaveToFile(string path, GameState game)
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"{game.Height} {game.Width}");

        // gooes through the board and converts states to numbers
        for (int row = 0; row < game.Height; row++)
        {
            for (int col = 0; col < game.Width; col++)
            {
                CellState currentCell = game.GetCell(row, col);
                
                int cellValue = currentCell switch
                {
                    CellState.Player1 => 1,
                    CellState.Player2 => 2,
                    _ => 0 // default
                };

                sb.Append(cellValue).Append(" ");
            }
        }

        // creates new file
        File.WriteAllText(path, sb.ToString().TrimEnd());
    }

    //public static GameState LoadFromFile(string path)
    //{

    //}
}