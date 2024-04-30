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
using Toonloon.Helpers;

namespace Toonloon
{
    [Activity(Label = "Home_Activity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Home_Activity : AppCompatActivity
    {
        GetImagesOnline gio= new GetImagesOnline();
        private SearchView searchView;
        ImageView img;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            EditText searchEditText = FindViewById<EditText>(Resource.Id.searchEditText);
            searchEditText.TextChanged += (sender, e) =>
            {
                // Perform search based on the entered text
                string searchText = e.Text.ToString();
                // Your search logic here
            };

            gio.GetImage(FindViewById<ImageView>(Resource.Id.mangaImage), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSxEXZvHhrZnrknHt2rKgGAmZZEnWt7zk7s9k4wapaJQw&s");
        }
    }
}