using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using CommonLib;
using System;

namespace DroidCornhole
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ICornholeViewManager
    {
        CornholeViewModel viewModel;
        protected Button BtnTeam1ThreePoints => (Button)FindViewById(Resource.Id.btnTeam13Point);
        protected Button BtnTeam1OnePoints => (Button)FindViewById(Resource.Id.btnTeam11Point);
        protected Button BtnTeam2ThreePoints => (Button)FindViewById(Resource.Id.btnTeam23Point);
        protected Button BtnTeam2OnePoints => (Button)FindViewById(Resource.Id.btnTeam21Point);
        protected Button BtnNextRound => (Button)FindViewById(Resource.Id.btnNextRound);
        protected TextView TvTeam1RoundScore => (TextView)FindViewById(Resource.Id.tvTeam1Round);
        protected TextView TvTeam2RoundScore => (TextView)FindViewById(Resource.Id.tvTeam2Round);
        protected TextView TvTeam1GameScore => (TextView)FindViewById(Resource.Id.tvTeam1Score);
        protected TextView TvTeam2GameScore => (TextView)FindViewById(Resource.Id.tvTeam2Score);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            viewModel = new CornholeViewModel(this);
            PointsButtons();
            NewRoundButton();
        }

        private void NewRoundButton()
        {
            BtnNextRound.Click += delegate
            {
                viewModel.NewRound();
            };
        }

        private void PointsButtons()
        {
            BtnTeam1ThreePoints.Click += delegate
            {
                viewModel.AddPoints(3, 1);
            };

            BtnTeam1OnePoints.Click += delegate
            {
                viewModel.AddPoints(1, 1);
            };

            BtnTeam2OnePoints.Click += delegate
            {
                viewModel.AddPoints(1, 2);
            };

            BtnTeam2ThreePoints.Click += delegate
            {
                viewModel.AddPoints(3, 2);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void UpdateRoundScore(int team1RoundScore, int team2RoundScore)
        {
            TvTeam1RoundScore.Text = team1RoundScore.ToString();
            TvTeam2RoundScore.Text = team2RoundScore.ToString();
        }

        public void UpdateGameScore(int team1GameScore, int team2GameScore)
        {
            TvTeam1GameScore.Text = team1GameScore.ToString();
            TvTeam2GameScore.Text = team2GameScore.ToString();
        }
    }
}