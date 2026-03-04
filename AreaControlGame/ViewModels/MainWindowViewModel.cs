using AreaControlGame.Models;
using System.IO;
using System;

namespace AreaControlGame.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public GameState CurrentGame { get; private set; }
    
    public MainWindowViewModel()
    {
        // 1 - get info from the txt (reads the entire thing) (Source: https://www.geeksforgeeks.org/c-sharp/how-to-read-and-write-a-text-file-in-c-sharp/ )
        string data_from_txt = File.ReadAllText("Assets/settings.txt");

        // 2 - extracts the numbers source:https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
        string[] parts = data_from_txt.Split(' ');
       
        int cols = int.Parse(parts[0]); //sets the first part of the extraction + translate them from strings to int
        int rows = int.Parse(parts[1]); //sets the seconds part of the extraion + translate them from strings to int

        CurrentGame = new GameState(rows, cols); // create a new GameState using our numbers and safes them   
    }
}