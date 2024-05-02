using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toonloon.DataModels;
using Toonloon.Helpers;

namespace Toonloon
{
    [Activity(Label = "MangaOverviewActivity")]
    public class MangaOverviewActivity : AppCompatActivity
    {
        TextView mangaName;
        ImageView mangaCover;
        Button backButton, startReading;
        
        GetImagesOnline gio = new GetImagesOnline();

        MockData MD = new MockData();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MangaOverview);

            mangaName = FindViewById<TextView>(Resource.Id.mangaNameTextView);
            mangaCover = FindViewById<ImageView>(Resource.Id.mangaCoverImageView);
            backButton = FindViewById<Button>(Resource.Id.BackButton);
            startReading = FindViewById<Button>(Resource.Id.startReadingButton);

            var manga = from mangaitem in MD.MangaList
                        where mangaitem.MangaID == Convert.ToInt32(Intent.GetStringExtra("MangaID"))
                        select mangaitem;


            mangaName.Text = manga.FirstOrDefault().MangaTitle;
            gio.GetImage(mangaCover, manga.FirstOrDefault().CoverURL);

            backButton.Click += BackButton_Click;
            startReading.Click += StartReading_Click;
        }

        private void StartReading_Click(object sender, EventArgs e)
        {
            Intent intent  = new Intent(this, typeof(ReadingLayoutActivity));
            intent.PutExtra("MangaID", Intent.GetStringExtra("MangaID"));

            StartActivity(intent);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}