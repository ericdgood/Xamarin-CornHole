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
        protected int UndoTeam1Score;
        protected int UndoTeam2Score;

        public CornholeViewModel(ICornholeViewManager viewManager)
        {
            this.viewManager = viewManager ?? throw new ArgumentNullException(nameof(viewManager));
        }

        public void OnAddPointsButtonClick(int Points, int TeamNumber)
        {
            UndoTeam1Score = Team1InningScore;
            UndoTeam2Score = Team2InningScore;

            if (TeamNumber == 1)
            {
                Team1InningScore += Points;
            }
            else
            {
                Team2InningScore += Points;
            }

            viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
        }

        public void OnNewInningButtonClick(int GameType)
        {
            Team1GameScore = (Team1InningScore - Team2InningScore) > 0 ? (Team1InningScore - Team2InningScore + Team1GameScore) : Team1GameScore;
            Team2GameScore = (Team2InningScore - Team1InningScore) > 0 ? (Team2InningScore - Team1InningScore + Team2GameScore) : Team2GameScore;
            Team1InningScore = 0;
            Team2InningScore = 0;

            SetGameType(GameType);
            viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
            viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);

            InningNumber++;
            viewManager.UpdateInningNumber(InningNumber);
            viewManager.WinningColors(WinningColors());
        }

        public void OnNewGameButtonClick()
        {
            Team1GameScore = 0;
            Team1InningScore = 0;
            Team2GameScore = 0;
            Team2InningScore = 0;
            InningNumber = 1;

            viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
            viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);
            viewManager.UpdateInningNumber(InningNumber);
            viewManager.WinningColors(3);
        }

        private int WinningColors()
        {
            return Team1GameScore > Team2GameScore ? 1 : Team2GameScore > Team1GameScore ? 2 : 3;
        }

        public void SetGameType(int GameType)
        {
            switch (GameType)
            {
                case 1:
                    GameType21Exactly();
                    break;
                case 2:
                    GameType21OrOver();
                    break;
                case 3:
                    // HighScore
                    break;
                case 4:
                    // 7/21
                    break;
                case 5:
                    // Go Long
                    break;
                default:
                    GameType21Exactly();
                    break;
            }
        }

        public void OnUndoButtonClick()
        {
            Team1InningScore = UndoTeam1Score;
            Team2InningScore = UndoTeam2Score;
            viewManager.UpdateInningScore(Team1InningScore, Team2InningScore);
        }

        private void GameType21OrOver()
        {
            if (Team1GameScore >= 21)
            {
                viewManager.ShowWinningMessage("Team 1 Wins");
            }
            if (Team2GameScore >= 21)
            {
                viewManager.ShowWinningMessage("Team 2 Wins");
            }
        }

        private void GameType21Exactly()
        {
            if (Team1GameScore == 21)
            {
                viewManager.ShowWinningMessage("Team 1 Wins");
            }
            if (Team1GameScore > 21)
            {
                Team1GameScore = 11;
                viewManager.ShowOver21Message("Team 1 has gone over 21. back to 11");
                viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);
            }

            if (Team2GameScore == 21)
            {
                viewManager.ShowWinningMessage("Team 2 Wins");
            }
            if (Team2GameScore > 21)
            {
                Team2GameScore = 11;
                viewManager.ShowOver21Message("Team 2 has gone over 21. back to 11");
                viewManager.UpdateGameScore(Team1GameScore, Team2GameScore);
            }
        }
    }
}

