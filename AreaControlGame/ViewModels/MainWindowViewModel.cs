using AreaControlGame.Models;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace AreaControlGame.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public GameState CurrentGame { get; private set; }
    
    // Properties for the XAML to know how big the grid is
    public int Rows { get; }
    public int Columns { get; }

    // This collection holds all our cells so the UI can draw them
    public ObservableCollection<CellViewModel> Cells { get; } = new();
    
    public MainWindowViewModel()
    {
        // 1 - get info from the txt (reads the entire thing)
        string data_from_txt = File.ReadAllText("Assets/settings.txt");

        // 2 - extracts the numbers
        string[] parts = data_from_txt.Split(' ');
       
        Columns = int.Parse(parts[0]); // sets the first part of the extraction + translate them from strings to int
        Rows = int.Parse(parts[1]); // sets the seconds part of the extraion + translate them from strings to int

        CurrentGame = new GameState(Rows, Columns); // create a new GameState using our numbers and safes them   

        // build grid data (moved from MainWindow.axaml.cs)
        // loop so all rows and collums get a cell
        // In AreaControlGame/ViewModels/MainWindowViewModel.cs

// inside the constructor loop:
            // AreaControlGame/ViewModels/MainWindowViewModel.cs loop update:

        for (int i = 0; i < Rows; i++) 
        {
            for (int y = 0; y < Columns; y++)
            {
                CellState cellValue = CurrentGame.GetCell(i, y);
                // Pass "CurrentGame" as the last argument here
                Cells.Add(new CellViewModel(i, y, cellValue, CurrentGame));
            }
        }
    }
}