using AreaControlGame.Models;
using System.IO;
using System;

namespace AreaControlGame.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // changes the greeting to the grid size
    public string Greeting { get; private set; }

    public static int Rows_user_set { get; private set; }
    public static int Cols_user_set { get; private set; }

    public static bool update_flag = false;

    public MainWindowViewModel()
    {
        {
            // 1 - get info from the txt (Source: https://www.geeksforgeeks.org/c-sharp/how-to-read-and-write-a-text-file-in-c-sharp/ )
            string data_from_txt = File.ReadAllText("Assets/settings.txt");

            // 2 - point the program to position 0 (height) and 2 (width)
            Rows_user_set = int.Parse(data_from_txt[0].ToString());
            Cols_user_set = int.Parse(data_from_txt[2].ToString());

            // 3 - give information to constructor
            var gameState = new GameState(Rows_user_set, Cols_user_set);

            update_flag = true;

            // just as test to see if it works:
            //Greeting = $"Grid {height} x {width}";
            
        }
    }
}

