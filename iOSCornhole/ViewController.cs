using Foundation;
using System;
using UIKit;
using CommonLib;

namespace iOSCornhole
{
    public partial class ViewController : UIViewController, ICornholeViewManager
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CornholeViewModel viewModel = new CornholeViewModel(this);

            OnPointButtonClick(viewModel);
            btnNewInning.TouchUpInside += (sender, e) => viewModel.NewInning();
            btnNewGame.TouchUpInside += (sender, e) => viewModel.NewGame();
        }

        private void OnPointButtonClick(CornholeViewModel viewModel)
        {
            btnTeam1ThreePoints.TouchUpInside += (sender, e) => viewModel.AddPoints(3, 1);
            btnTeam1OnePoint.TouchUpInside += (sender, e) => viewModel.AddPoints(1, 1);
            btnTeam2OnePoint.TouchUpInside += (sender, e) => viewModel.AddPoints(1, 2);
            btnTeam2ThreePoints.TouchUpInside += (sender, e) => viewModel.AddPoints(3, 2);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void UpdateInningScore(int team1InningScore, int team2InningScore)
        {
            tvTeam1InningScore.Text = team1InningScore.ToString();
            tvTeam2InningScore.Text = team2InningScore.ToString();
        }

        public void UpdateGameScore(int team1GameScore, int team2GameScore)
        {
            tvTeam1GameScore.Text = team1GameScore.ToString();
            tvTeam2GameScore.Text = team2GameScore.ToString();
        }

        public void UpdateInningNumber(int inningNumber)
        {
            tvInningNumber.Text = inningNumber.ToString();
        }
    }
}