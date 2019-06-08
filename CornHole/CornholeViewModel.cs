using System;
namespace CommonLib
{
    public class CornholeViewModel
    {
        protected ICornholeViewManager viewManager;
        protected int Team1GameScore;
        protected int Team1RoundScore;
        protected int Team2GameScore;
        protected int Team2RoundScore;

        public CornholeViewModel(ICornholeViewManager viewManager)
        {
            this.viewManager = viewManager ?? throw new ArgumentNullException(nameof(viewManager));
        }

        public void AddPoints(int Points, int TeamNumber)
        {
            if (TeamNumber == 1)
            {
                Team1RoundScore += Points;
                viewManager.UpdateRoundScore(Team1RoundScore, Team2RoundScore);
            }
            else
            {
                Team2RoundScore += Points;
                viewManager.UpdateRoundScore(Team1RoundScore, Team2RoundScore);
            }
        }

        public void NewRound()
        {
            Team1GameScore = (Team1RoundScore - Team2RoundScore) > 0 ? (Team1RoundScore - Team2RoundScore + Team1GameScore) : Team1GameScore;
            Team2GameScore = (Team2RoundScore - Team1RoundScore) > 0 ? (Team2RoundScore - Team1RoundScore + Team2GameScore) : Team2GameScore;
            Team1RoundScore = 0;
            Team2RoundScore = 0;

            viewManager.UpdateRoundScore(Team1RoundScore, Team2RoundScore);
            viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);
        }
    }
}

