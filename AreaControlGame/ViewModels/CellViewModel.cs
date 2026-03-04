using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using AreaControlGame.Models;
using System.Windows.Input;

namespace AreaControlGame.ViewModels;

public partial class CellViewModel : ObservableObject // partial treats the entire CellViewModel as one class
{
    public int Row { get; } 
    public int Column { get; }

    //command is injected by GameViewModel
    public ICommand ClickCommand { get; }

    //private readonly GameState _gameState;

    [ObservableProperty]
    
    [NotifyPropertyChangedFor(nameof(CellColor))] 
    private CellState state;

    public CellViewModel(int row, int column, CellState initialState, ICommand clickCommand)
    {
        Row = row;
        Column = column;
        state = initialState; 
        ClickCommand = clickCommand; //not state, but click command
    }

    public string CellColor
    {
        get
        {
            switch (State)
            {
                case CellState.Player1:
                    return "LightBlue";
                case CellState.Player2:
                    return "LightCoral";
                default: // default
                    return "White";
            }
        }
    }

    // [RelayCommand]
    // private void ClickCell()
    // {
    //     // 1. Logic: Don't allow changing the color if it is already occupied
    //     if (State != CellState.Empty) return;

    //     // 3. Brain: Tell the game state to record the move and swap turns
    //     bool moved = _gameState.TryMakeMove(Row, Column);

    //     if (!moved)
    //     {
    //         // 2. Visual: Set the visual state to the current player
    //     State = _gameState.CurrentPlayer;
    //     }
    // }
}