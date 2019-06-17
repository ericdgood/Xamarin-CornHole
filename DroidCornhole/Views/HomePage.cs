
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DroidCornhole.Views
{
    [Activity(Label = "HomePage", MainLauncher = true)]
    public class HomePage : Activity
    {
        Button Btn21OrOver => (Button)FindViewById(Resource.Id.btn21OrOver);
        Button Btn21Exactly => (Button)FindViewById(Resource.Id.btn21Excatly);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.home_page);

            Btn21OrOver.Click += delegate
            {
                StartGameOnClick(2);
            };

            Btn21Exactly.Click += delegate
            {
                StartGameOnClick(1);
            };
        }

        private void StartGameOnClick(int GameType)
        {
            Intent SendGameTypeIntent = new Intent(this, typeof(MainActivity));
            SendGameTypeIntent.PutExtra("GameType", GameType);
            StartActivity(SendGameTypeIntent);
        }
    }
}
