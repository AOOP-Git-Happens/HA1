// Idea: is the translator for the overall gameboard and match status. I write in here to connect the game logic to the ui 

//gameviewmodel owns gamestate
//exposes rows, columns, cellviewmodel collection
//clicks with command
//updates statustext after every move
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AreaControlGame.Models;

namespace AreaControlGame.ViewModels;

public partial class GameViewModel : ObservableObject
{
    private readonly GameState _game;

    public int Rows => _game.Height;
    public int Columns => _game.Width;

    public ObservableCollection<CellViewModel> Cells { get; } = new();

    [ObservableProperty]
    private string statusText = "";

    public GameViewModel(GameState game)
    {
        _game = game;

        BuildCellsFromModel();//only place that builds cells
        UpdateStatusText();
    }

    private void BuildCellsFromModel()
    {
        Cells.Clear();

        for (int row = 0; row < _game.Height; row++)
        {
            for (int column = 0; column < _game.Width; column++)
            {
                // Each cell gets a reference to the click command
                Cells.Add(new CellViewModel(row, column, _game.Board[row, column], CellClickedCommand));
            }
        }
    }

    private void SyncCellsFromModel()
    {
        foreach (var cell in Cells)
        {
            cell.State = _game.Board[cell.Row, cell.Column];
        }
    }

    [RelayCommand]
    private void CellClicked(CellViewModel? cell)
    {
        if (cell is null)
            return;

        // Ask the model to try the move
        bool moved = _game.TryMakeMove(cell.Row, cell.Column);

        if (!moved)
        {
            // Optional: show feedback like "Illegal move"
            // StatusText = "Illegal move";
            return;
        }

        // If move succeeded, sync view models from the model
        SyncCellsFromModel();
        UpdateStatusText();
    }

    private void UpdateStatusText()
    {
        switch (_game.Result)
        {
            case GameResult.Ongoing:
                StatusText = $"{_game.CurrentPlayer} to move";
                break;

            case GameResult.Draw:
                StatusText = "Draw!";
                break;

            case GameResult.Player1Wins:
                StatusText = "Player 1 wins!";
                break;

            case GameResult.Player2Wins:
                StatusText = "Player 2 wins!";
                break;
        }
    }

    // Optional: call this from a "New Game" button later
    [RelayCommand]
    private void NewGame()
    {
        _game.Reset();
        SyncCellsFromModel();
        UpdateStatusText();
    }
}   