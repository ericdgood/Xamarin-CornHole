using System;
namespace CommonLib
{
    public interface ICornholeViewManager
    {
        void UpdateInningScore(int team1RoundScore, int team2RoundScore);
        void UpdateGameScore(int team1GameScore, int team2GameScore);
        void UpdateInningNumber(int inningNumber);
    }
}
