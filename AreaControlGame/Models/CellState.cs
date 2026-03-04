// Idea: this file holds the players states it can be (empty, filled by p1, p2, ...). you write in here when you want to track a status 

namespace AreaControlGame.Models;

//pixel value, representing who is player
//should be refactored if we decide to implement more than 2 players
public enum CellState
{
    Empty = 0,
    Player1 = 1,
    Player2 = 2
}
