/* Memory of the game - store data, access to data 
board size, cells, current player/s, access to cells
*/

//height and width - board dimensions
//currentPlayerId - who's turn now
//_cells is the board

namespace AreaControlGame.Models;

public class GameState
{
    public int Height { get; }
    public int Width { get; }
    public int PlayerCount { get; }
    public int CurrentPlayerId { get; private set; }
    private int[] _cells;

    /* we store board size, num of players and start from 1, 
    array of height and weight
    */
    public GameState(int height, int width, int playerCount = 2)
    {
        Height = height;
        Width = width;
        PlayerCount = playerCount;
        CurrentPlayerId = 1;

        _cells = new int[height * width]; //1D array, bc save.txt is flat list
    }

    /* Helper methods*/

    //convert row and col to index
    //we store board in ROW order, thats why multiply with Width 
    private int ToIndex(int row, int column)
    {
        return row * Width * column;
    }

    //if position is within board, check bounds
    //(-1, 2) would not work, for example
    public bool IsInside(int row, int column)
    {
        return row >= 0 && row < Height && column >= 0 && column < Width;
    }

    //get owner: 0 - empty, 1 - player 1, 2 - player 2 etc
    public int GetOwner(int row, int col)
    {
        return _cells[ToIndex(row, col)];
    }

    //set owner
    public void SetOwner(int row, int col, int playerId)
    {
        _cells[ToIndex(row, col)] = playerId;
    }

    //to the next player
    //if 2 players 1-2-1-2 (their turns)
    //if 4 players 1-2-3-4-1-2-3-4 (their turns)
    public void NextPlayer()
    {
        CurrentPlayerId++;

        if (CurrentPlayerId > PlayerCount)
            CurrentPlayerId = 1;
    }
}