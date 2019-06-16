using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using CommonLib;
using System;
using Android.Content;

namespace DroidCornhole
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ICornholeViewManager
    {
        CornholeViewModel viewModel;
        protected Button BtnTeam1ThreePoints => (Button)FindViewById(Resource.Id.btnTeam13Point);
        protected Button BtnTeam1OnePoints => (Button)FindViewById(Resource.Id.btnTeam11Point);
        protected Button BtnTeam2ThreePoints => (Button)FindViewById(Resource.Id.btnTeam23Point);
        protected Button BtnTeam2OnePoints => (Button)FindViewById(Resource.Id.btnTeam21Point);
        protected Button BtnNextInning => (Button)FindViewById(Resource.Id.btnNextInning);
        protected Button BtnNewGame => (Button)FindViewById(Resource.Id.btnNewGame);
        protected Button BtnUndo => (Button)FindViewById(Resource.Id.btnUndo);
        protected TextView TvTeam1InningScore => (TextView)FindViewById(Resource.Id.tvTeam1Inning);
        protected TextView TvTeam2InningScore => (TextView)FindViewById(Resource.Id.tvTeam2Inning);
        protected TextView TvTeam1GameScore => (TextView)FindViewById(Resource.Id.tvTeam1Score);
        protected TextView TvTeam2GameScore => (TextView)FindViewById(Resource.Id.tvTeam2Score);
        protected TextView TvInningNumber => (TextView)FindViewById(Resource.Id.tvInningNumber);
        // Team names
        protected TextView TvTeam1Name => (TextView)FindViewById(Resource.Id.tvTeam1Name);
        protected TextView TvTeam2Name => (TextView)FindViewById(Resource.Id.tvTeam2Name);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            viewModel = new CornholeViewModel(this);
            OnPointsAddButtonClick();
            OnNewInningButtonClick();
            OnNewGameButtoClick();
            OnUndoButtonClick();

            TvTeam1Name.Text = "Tea 1 Name";
            TvTeam2Name.Text = "Team 2 Name";
        }

        private void OnUndoButtonClick()
        {
            BtnUndo.Click += delegate
            {
                viewModel.OnUndoButtonClick();
            };
        }

        private void OnNewGameButtoClick()
        {
            BtnNewGame.Click += delegate
            {
                viewModel.OnNewGameButtonClick();
            };
        }

        private void OnNewInningButtonClick()
        {
            BtnNextInning.Click += delegate
            {
                viewModel.OnNewInningButtonClick();
            };
        }

        private void OnPointsAddButtonClick()
        {
            BtnTeam1ThreePoints.Click += delegate
            {
                viewModel.OnAddPointsButtonClick(3, 1);
            };

            BtnTeam1OnePoints.Click += delegate
            {
                viewModel.OnAddPointsButtonClick(1, 1);
            };

            BtnTeam2OnePoints.Click += delegate
            {
                viewModel.OnAddPointsButtonClick(1, 2);
            };

            BtnTeam2ThreePoints.Click += delegate
            {
                viewModel.OnAddPointsButtonClick(3, 2);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void UpdateInningScore(int team1InningScore, int team2InningScore)
        {
            TvTeam1InningScore.Text = team1InningScore.ToString();
            TvTeam2InningScore.Text = team2InningScore.ToString();
        }

        public void UpdateGameScore(int team1GameScore, int team2GameScore)
        {
            TvTeam1GameScore.Text = team1GameScore.ToString();
            TvTeam2GameScore.Text = team2GameScore.ToString();
        }

        public void UpdateInningNumber(int inningNumber)
        {
            TvInningNumber.Text = inningNumber.ToString();
        }

        public void WinningColors(int leadingTeam)
        {
            if (leadingTeam == 1)
            {
                TvTeam1Name.SetBackgroundColor(Android.Graphics.Color.Green);
                TvTeam2Name.SetBackgroundColor(Android.Graphics.Color.Red);
            }
            if (leadingTeam == 2)
            {
                TvTeam2Name.SetBackgroundColor(Android.Graphics.Color.Green);
                TvTeam1Name.SetBackgroundColor(Android.Graphics.Color.Red);
            }
            if (leadingTeam == 3)
            {
                TvTeam1Name.SetBackgroundColor(Android.Graphics.Color.Transparent);
                TvTeam2Name.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

        public void ShowWinningMessage(string WinngMessage)
        {
            Toast.MakeText(this, WinngMessage, ToastLength.Short).Show();
        }

        public void ShowOver21Message(string Over21Message)
        {
            Toast.MakeText(this, Over21Message, ToastLength.Short).Show();

        }
    }
}