// Idea: this states the states the game is in. You dont write here anything new except when new variables come in like new players

namespace AreaControlGame.Models;

public enum GameResult
{
    Ongoing,
    Draw,
    Player1Wins,
    Player2Wins
}