using System.Windows.Input;
//toolkit for ObservableProperty
using CommunityToolkit.Mvvm.ComponentModel;
using AreaControlGame.Models;

namespace AreaControlGame.ViewModels;

public partial class CellViewModel : ObservableObject
{
    public int Row { get; }
    public int Column { get; }

    [ObservableProperty]
    private CellState state;

    public CellViewModel(int row, int column, CellState initialState)
    {
        Row = row;
        Column = column;
        state = initialState;
    }
}