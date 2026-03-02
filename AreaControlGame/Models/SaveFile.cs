using System;
using System.IO;
using System.Text;

namespace AreaControlGame.Models;

/*Remember format
Height Width
cell0 cell1 cell3 cell4 cellN
0 - empty,
1 - player1,
2 - player2
*/
public static class SaveFile
{
    public static void SaveToFile(string path, GameState game)
    {
        throw new NotImplementedException();
    }

    public static GameState LoadFromFile(string path)
    {
        throw new NotImplementedException();
    }
}