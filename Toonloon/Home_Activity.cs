using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Firestore.Model;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toonloon.DataModels;
using Toonloon.Helpers;
using Android.Gms.Extensions;
using Java.Util;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Toonloon.EventListeners;
using Android.Gms.Tasks;

namespace Toonloon
{
    [Activity(Label = "Home_Activity", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Home_Activity : AppCompatActivity, IOnSuccessListener
    {
        GetImagesOnline gio= new GetImagesOnline();
        private SearchView searchView;
        ImageView img;
        LinearLayout recommendedLayout;
        FirebaseFirestore db;
        AppDataHelper appDataHelper = new AppDataHelper();
        List<Manga> mangaList = new List<Manga>();
        TaskCompletionListener TCL = new TaskCompletionListener();
        MockData MD = new MockData();

        public void OnSuccess(Java.Lang.Object result)
        {
            var snapshot = (QuerySnapshot)result;
            if (snapshot != null)
            {
                var documents = snapshot.Documents;

                foreach (DocumentSnapshot document in documents)
                {
                    Manga manga = new Manga();

                    manga.MangaTitle = document.Get("MangaTitle").ToString() != null ? document.Get("MangaTitle").ToString() : "";
                    manga.CoverURL = document.Get("CoverURL").ToString() != null ? document.Get("CoverURL").ToString() : "";

                    mangaList.Add(manga);
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            recommendedLayout = FindViewById<LinearLayout>(Resource.Id.RecommendedLayout);
            EditText searchEditText = FindViewById<EditText>(Resource.Id.searchEditText);

            searchEditText.TextChanged += (sender, e) =>
            {
                // Perform search based on the entered text
                string searchText = e.Text.ToString();
                // Your search logic here
            };

            FetchData();

            foreach(var item in MD.MangaList)
            {
                var imageview = new ImageView(this)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                    ConvertDpToPixels(180),
                    ConvertDpToPixels(180)
                )

                };
                gio.GetImage(imageview, item.CoverURL);
                recommendedLayout.AddView(imageview);

                imageview.Click += (sender, e) =>
                {
                    Intent intent = new Intent(this, typeof(MangaOverviewActivity));
                    intent.PutExtra("MangaID", item.MangaID.ToString());

                    StartActivity(intent);
                };
            }



            //for(int i = 0; i < 10; i++)
            //{
            //    var manga = new Manga()
            //    {
            //        MangaTitle = "Solo Leveling",
            //        CoverUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSxEXZvHhrZnrknHt2rKgGAmZZEnWt7zk7s9k4wapaJQw&s"
            //    };
            //    var imageview = new ImageView(this)
            //    {
            //        LayoutParameters = new LinearLayout.LayoutParams(
            //                ConvertDpToPixels(180),
            //                ConvertDpToPixels(180)
            //            )

            //    };
            //    gio.GetImage(imageview, manga.CoverUrl);
            //    recommendedLayout.AddView(imageview);

            //    imageview.Click += (sender, e) =>
            //    {
            //        Intent intent = new Intent(this, typeof(MangaOverviewActivity));
            //        intent.PutExtra("MangaTitle", "Solo Leveling");
            //        intent.PutExtra("MangaCover", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSxEXZvHhrZnrknHt2rKgGAmZZEnWt7zk7s9k4wapaJQw&s");

            //        StartActivity(intent);
            //    };
            //}

        }

        private int ConvertDpToPixels(int dp)
        {
            return (int)(dp * Resources.DisplayMetrics.Density);
        }
        private void FetchData()
        {
            db = appDataHelper.GetFirestore();
            db.Collection("Toon").Get()
                .AddOnSuccessListener(this);

        }

    }
}