//Idea: this is the brain of the system. It connects to 
//the other files. You write in here for all rules/setup stuff

using System;
namespace AreaControlGame.Models;

public class GameState
{
    //public - used by ViewModel
    public int Height { get; }
    public int Width { get; }
    //2D array board
    public CellState[,] Board { get; }

    public CellState CurrentPlayer { get; private set; }
    public GameResult Result { get; private set; }

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
        Array.Clear(Board, 0, Board.Length);
        CurrentPlayer = CellState.Player1;
        Result = GameResult.Ongoing;
    }
    public CellState GetCell(int row, int column)
    {
        return Board[row, column];
    }

    public bool TryMakeMove(int row, int column)
    {
        if (Result != GameResult.Ongoing)
        {
            return false;
        }
        if (!IsLegalMove(row, column, CurrentPlayer))
        {
            return false;
        }
        MakePiece(row, column);

        //draw board is full
        if (IsBoardFull())
        {
            Result = GameResult.Draw;
            SaveFile.SaveToFile("Assets/settings.txt", this); // 
            
            return true;
        }
        
        //win - if next player has no legal moves - current player wins
        var nextPlayer = GetOtherPlayer(CurrentPlayer);

        if (!HasAnyLegalMove(nextPlayer))
        {
            Result = (CurrentPlayer == CellState.Player1 ? GameResult.Player1Wins : GameResult.Player2Wins);
            SaveFile.SaveToFile("Assets/settings.txt", this);
            return true;
        }
        
        //otherwise
        CurrentPlayer = nextPlayer;

        // Auto-save the current state to a text file after a normal move
        SaveFile.SaveToFile("Assets/settings.txt", this);

        return true;
    }

    
    private void MakePiece(int row, int column)
    {
        Board[row, column] = CurrentPlayer; // updates the board with the right row/colum the player changes to
    }

    //helper to be inside the scope)
    private bool IsInside(int row, int column)
    {
        return row >= 0 && column >= 0 && row < Height && column < Width;
    }

    private bool IsEmpty(int row, int column)
    {
        return Board[row, column] == CellState.Empty;
    }

    //whatever player has placed smth before. 
    //if 0 pieces -> first move, allow any empty cell

    //if has some pieces -> must be adjacent
    private bool PlayerHasAnyCells(CellState player)
    {
        foreach (var cell in Board)
        {
            if (cell == player)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsLegalMove(int row, int column, CellState player)
    {
        if (!IsInside(row, column))
        {
            return false;
        }
        if (!IsEmpty(row, column))
        {
            return false;
        }
        if (!PlayerHasAnyCells(player))
        {
            return true;
        }
        //adjacency, check up to 8 surounding cells
        //center is dr =0, dc=0
        for (int rowChange = -1; rowChange <= 1; rowChange++)
        {
            for (int columnChange = -1; columnChange <= 1; columnChange++)
            {
                if (rowChange == 0 && columnChange == 0)
                {
                    continue;
                }

                int newRow = row + rowChange;
                int newColumn = column + columnChange;

                if (!IsInside(newRow, newColumn))
                {
                    continue;
                }
                if (Board[newRow, newColumn] == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsBoardFull()
    {
        foreach (var cell in Board)
        {
            if (cell == CellState.Empty)
            return false;
        }
        return true;
    }

    private bool HasAnyLegalMove(CellState player)
    {
        for (int row = 0; row < Height; row++)
        {
            for (int column = 0; column < Width; column++)
            {
                if (IsEmpty(row, column) && IsLegalMove(row, column, player))
                    return true;
            }
        }
        return false;
    }

    private CellState GetOtherPlayer(CellState player)
    {
        if (player == CellState.Player1)
        {
            return CellState.Player2;
        }
        else return CellState.Player1;
    }
}