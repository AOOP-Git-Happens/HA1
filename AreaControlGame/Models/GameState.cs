//Idea: this is the brain of the system. It connects to the other files. You write in here for all rules/setup stuff

using System;
namespace AreaControlGame.Models;

public class GameState
{
    public int Height { get;}
    public int Width { get;}
    //2D array board
    public CellState[,] Board { get; }

    public CellState CurrentPlayer {get; private set;}
    public GameResult Result { get; private set;}

    public GameState(int height, int width)
    {
        Height = height;
        Width = width;

        Board = new CellState[Height, Width];

        CurrentPlayer = CellState.Player1;
        Result = GameResult.Ongoing;
    }

    //clear board
    public void Reset()
    {
        
    }
    public CellState GetCell(int row, int column)
    {
        return Board[row, column];
    }

    //first move of a player can be anywhere empty

    //otherwise - adjacent (diagonals too) to an existing cell

    //if board full - draw
    // public bool TryMakeMove(int row, int column)
    // {
        
    // }

    //if next player has no (legal moves) - current player wins
    // public bool IsLegalMove(int row, int column, CellState player)
    // {
        
    // }    
}