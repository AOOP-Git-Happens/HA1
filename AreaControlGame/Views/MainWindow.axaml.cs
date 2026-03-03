using AreaControlGame.ViewModels;
using System.Data;
using AreaControlGame.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System.Threading.Tasks;

namespace AreaControlGame.Views;

public partial class MainWindow : Window
{
    int Rows = 0;//= MainWindowViewModel.Rows_user_set; //NEEDS TO BE CHANGES
    int Cols = 0;//= MainWindowViewModel.Cols_user_set; //NEEDS TO BE CHANGED
    private readonly IBrush _baseColor = Brushes.LightGray; //this is the normal tile colour
    private readonly IBrush _p1Color = Brushes.Blue; //color that the tile should be if player 1 occupies
    private readonly IBrush _p2Color = Brushes.Red; //color that the tile should be if player 2 occupies
    private int[,] _cellsMatrix; 
    
    public MainWindow() 
    {
        InitializeComponent();
        
        WaitForFlag();
        //InitGrid();
    }

    private async void WaitForFlag() //the programm had the issue that it was too fast and it didnt wait to get Rows.user.set and just instanly made it 0
    {
        while (MainWindowViewModel.update_flag == false)
        {
            // waits a bit
            await Task.Delay(100); 
        }

        // updates the numbers
        Rows = MainWindowViewModel.Rows_user_set;
        Cols = MainWindowViewModel.Cols_user_set;

        // builds grid
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