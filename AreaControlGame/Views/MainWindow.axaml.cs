using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AreaControlGame.Views;

public partial class MainWindow : Window
{
    private const int Rows = 10; //NEEDS TO BE CHANGES
    private const int Cols = 10; //NEEDS TO BE CHANGED
    private readonly IBrush _baseColor = Brushes.LightGray; //this is the normal tile colour
    private readonly IBrush _p1Color = Brushes.Blue; //color that the tile should be if player 1 occupies
    private readonly IBrush _p2Color = Brushes.Red; //color that the tile should be if player 2 occupies
    private int[,] _cellsMatrix; 
    
    public MainWindow() //runs these 
    {
        InitializeComponent();
        InitGrid(); 
    }

    //Init the Grid with its function
    private void InitGrid() 
    {
        _cellsMatrix = new int[Rows, Cols]; //sets the size of the array (matrix) to the rows and collums
        
        for (int i = 0; i < Rows; i++) 
        {
            PlayfieldGrid.RowDefinitions.Add(new RowDefinition()); 
            PlayfieldGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int y = 0; y < Cols; y++)
            {

                int cellValue = _cellsMatrix[i, y];

                var child = new Rectangle
                {
                    Margin = new Avalonia.Thickness(3), 
                };

                switch(cellValue)
                {
                    case 1:
                        child.Fill = _p1Color;
                        break;
                    
                    case 2:
                        child.Fill = _p2Color;
                        break;
                    
                    default:
                        child.Fill = _baseColor;
                        break;
                }

                Grid.SetRow(child, i); 
                Grid.SetColumn(child, y); 
                
                PlayfieldGrid.Children.Add(child);
            }
        }
    }
}