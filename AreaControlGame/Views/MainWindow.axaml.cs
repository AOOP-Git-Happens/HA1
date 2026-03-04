using AreaControlGame.ViewModels;
using AreaControlGame.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AreaControlGame.Views;

public partial class MainWindow : Window
{
    private readonly IBrush _baseColor = Brushes.LightGray; //this is the normal tile colour
    private readonly IBrush _p1Color = Brushes.Blue; //color that the tile should be if player 1 occupies
    private readonly IBrush _p2Color = Brushes.Red; //color that the tile should be if player 2 occupies
    
    public MainWindow() 
    {
        InitializeComponent(); // builts avalonia ui
        
        var viewModel = new MainWindowViewModel(); //I be honest no idea what that does rly but work @Alina pls help me 

        InitGrid(viewModel.CurrentGame); //inits the grid with the current txt size file 
    }

    //Init the Grid
    private void InitGrid(GameState gameState) 
    {
        // reads the size from gamestate var
        int rows = gameState.Height; 
        int cols = gameState.Width;

        // build grid
        // creates the rows
        for (int i = 0; i < rows; i++) 
        {
            PlayfieldGrid.RowDefinitions.Add(new RowDefinition()); //creates horizontal slice
        }
        
        // creates the cols
        for (int y = 0; y < cols; y++)
        {
            PlayfieldGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        // loop so all rows and collums get a cell
        for (int i = 0; i < rows; i++) 
        {
            for (int y = 0; y < cols; y++)
            {
                // ask who owns this square
                CellState cellValue = gameState.GetCell(i, y);

                // rectangle as form
                var child = new Rectangle
                {
                    Margin = new Avalonia.Thickness(3), //outline
                };

                // color the rectangle
                if (cellValue == CellState.Player1)
                {
                    child.Fill = _p1Color;
                }
                else if (cellValue == CellState.Player2)
                {
                    child.Fill = _p2Color;
                }
                else
                {
                    child.Fill = _baseColor;
                }

                // give the rectangles the right postion in the grid
                Grid.SetRow(child, i); 
                Grid.SetColumn(child, y); 
                
                // Add it to the screen
                PlayfieldGrid.Children.Add(child);
            }
        }
    }
}