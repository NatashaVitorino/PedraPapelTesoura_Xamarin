using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Webkit;
using AndroidX.AppCompat.App;

namespace Jyankenpo
{
    [Activity(Label = "SiteMain")]
    public class SiteMain : Activity
    {
        EditText txtUrl;
        Button btnIr;
        WebView webView1;
        string url;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Site);

            txtUrl = FindViewById<EditText>(Resource.Id.txtUrl);
            btnIr = FindViewById<Button>(Resource.Id.btnIr);
            webView1 = FindViewById<WebView>(Resource.Id.webView1);
            webView1.Settings.JavaScriptEnabled = true;

            btnIr.Click += BtnIr_Click;
        }

        private void BtnIr_Click(object sender, EventArgs e)
        {                                           
            webView1.SetWebViewClient(new MeuWebViewClient());
            url = txtUrl.Text;
            if (!url.Contains("https://www.youtube.com/watch?v=wEsLyZrCrak"))
            {
                url = "https://www.youtube.com/watch?v=wEsLyZrCrak" + url;
            }
            webView1.LoadUrl(url);
        }
        public class MeuWebViewClient : WebViewClient
        {
            [System.Obsolete]

            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }
    }
}