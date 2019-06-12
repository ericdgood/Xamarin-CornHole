
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CommonLib;

namespace DroidCornhole.Views
{
    [Activity(Label = "HomePage", Theme = "@style/AppTheme", MainLauncher = true)]
    public class HomePage : AppCompatActivity
    {
        HomePageViewModel viewModel;
        protected EditText EtTeam1Name => (EditText)FindViewById(Resource.Id.etTeam1Name);
        protected EditText EtTeam2Name => (EditText)FindViewById(Resource.Id.etTeam2Name);
        protected Button BtnPlayGame => (Button)FindViewById(Resource.Id.btnPlayGame);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.home_page);

            viewModel = new HomePageViewModel();
            BtnPlayGame.Click += BtnPlayGame_Click;
        }

        private void BtnPlayGame_Click(object sender, EventArgs e)
        {
            Intent StartGame = new Intent(this, typeof(MainActivity));
            // TODO Check if null
            StartGame.PutExtra("Team1Name", EtTeam1Name.Text);
            StartGame.PutExtra("Team2Name", EtTeam2Name.Text);
            StartActivity(StartGame);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
