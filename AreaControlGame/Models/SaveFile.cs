// Idea: this file is for loading and saving the current situation. Bassicly it needs to convert the boards situation into the txt or the other way around

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace AreaControlGame.Models;

/*Remember format
Height Width
cell0 cell1 cell3 cell4 cellN
0 - empty,
1 - player1,
2 - player2
*/


//public static class SaveFile
public class SaveFile
{
    public int Row { get; } 
    public int Column { get; }
    public GameState CurrentGame { get; }
    public static void SaveToFile(string path, GameState game)
    {
        int [] flatArray = new int [Row * Coloumn];
        for (int i = 0; i < Row; i++)
        {
            for (int y = 0; y < Column; y++)
            {
                int cell = CurrentGame.GetCell(i, y);
                flatArray[index++] = cell;
            }
        }
        string output = string.Join(" ", flatArray);
        File.WriteAllText("settings.txt", output);
        //throw new NotImplementedException();
    }

    public static GameState LoadFromFile(string path)
    {
        throw new NotImplementedException();
    }
}