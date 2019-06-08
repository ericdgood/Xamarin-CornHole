using System;
namespace CommonLib
{
    public class CornholeViewModel
    {
        protected ICornholeViewManager viewManager;
        protected int Team1GameScore;
        protected int Team1InningScore;
        protected int Team2GameScore;
        protected int Team2InningScore;
        protected int InningNumber = 1;

        public CornholeViewModel(ICornholeViewManager viewManager)
        {
            this.viewManager = viewManager ?? throw new ArgumentNullException(nameof(viewManager));
        }

        public void AddPoints(int Points, int TeamNumber)
        {
            if (TeamNumber == 1)
            {
                Team1InningScore += Points;
                viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
            }
            else
            {
                Team2InningScore += Points;
                viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
            }
        }

        public void NewInning()
        {
            Team1GameScore = (Team1InningScore - Team2InningScore) > 0 ? (Team1InningScore - Team2InningScore + Team1GameScore) : Team1GameScore;
            Team2GameScore = (Team2InningScore - Team1InningScore) > 0 ? (Team2InningScore - Team1InningScore + Team2GameScore) : Team2GameScore;
            Team1InningScore = 0;
            Team2InningScore = 0;

            viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
            viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);

            InningNumber++;
            viewManager.UpdateInningNumber(InningNumber);
        }

        public void NewGame()
        {
            Team1GameScore = 0;
            Team1InningScore = 0;
            Team2GameScore = 0;
            Team2InningScore = 0;
            InningNumber = 1;

            viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
            viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);
            viewManager.UpdateInningNumber(InningNumber);
        }
    }
}

