using AreaControlGame.Models;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace AreaControlGame.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    //view binds to this (Game.Cells/Rows/StatusText)
    public GameViewModel Game { get; }
    /*this code dublicates GameViewModel
    */
    // public GameState CurrentGame { get; private set; }

    // Properties for the XAML to know how big the grid is
    // public int Rows { get; }
    // public int Columns { get; }

    // This collection holds all our cells so the UI can draw them
    // public ObservableCollection<CellViewModel> Cells { get; } = new();

    public MainWindowViewModel()
    {
        ///works for 10 10 too
        int height = 6;
        int width = 6;

        try
        {
            // 1 - get info from the txt (reads the entire thing)
            string data_from_txt = File.ReadAllText("Assets/settings.txt");
            //for removing empty spaces
            var parts = data_from_txt.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);


            // 2 - extracts the numbers
            //string[] parts = data_from_txt.Split(' ');

            if (parts.Length >= 2)
            {
                height = int.Parse(parts[0]); // sets the first part of the extraction + translate them from strings to int
                width = int.Parse(parts[1]); // sets the seconds part of the extraion + translate them from strings to int
            }
        }
        catch
        {
        }
        //CurrentGame = new GameState(Rows, Columns); // create a new GameState using our numbers and safes them  
        var gameState = new GameState(height, width);
        Game = new GameViewModel(gameState);
    }
    // build grid data (moved from MainWindow.axaml.cs)
    // loop so all rows and collums get a cell
    // In AreaControlGame/ViewModels/MainWindowViewModel.cs

    // inside the constructor loop:
    // AreaControlGame/ViewModels/MainWindowViewModel.cs loop update:

    // for (int i = 0; i < Rows; i++) 
    // {
    //     for (int y = 0; y < Columns; y++)
    //     {
    //         CellState cellValue = CurrentGame.GetCell(i, y);
    //         // Pass "CurrentGame" as the last argument here
    //         Cells.Add(new CellViewModel(i, y, cellValue, CurrentGame));
    //     }
    // }
}
