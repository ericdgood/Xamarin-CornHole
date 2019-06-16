using System;
namespace CommonLib
{
    public interface ICornholeViewManager
    {
        void UpdateInningScore(int team1InningScore, int team2InningScore);
        void UpdateGameScore(int team1GameScore, int team2GameScore);
        void UpdateInningNumber(int inningNumber);
        void WinningColors(int leadingTeam);
        void ShowWinningMessage(string WinningMessage);
        void ShowOver21Message(string Over21Message);
    }
}
