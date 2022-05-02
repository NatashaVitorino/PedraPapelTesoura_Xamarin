using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;

namespace Jyankenpo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnSite, btnJogar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnJogar = FindViewById<Button>(Resource.Id.btnJogar);
            btnSite = FindViewById<Button>(Resource.Id.btnSite);

            btnSite.Click += BtnSite_Click;
            btnJogar.Click += BtnJogar_Click;

        }

        private void BtnJogar_Click(object sender, System.EventArgs e)
        {
            Intent Jogo = new Intent(this, typeof(JogoMain));
            StartActivity(Jogo);
        }

        private void BtnSite_Click(object sender, System.EventArgs e)
        {
            Intent Site = new Intent(this, typeof(SiteMain));
            StartActivity(Site);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}