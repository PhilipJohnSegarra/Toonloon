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

namespace Toonloon
{
    [Activity(Label = "Home_Activity")]
    public class Home_Activity : Activity
    {
        private SearchView searchView;

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

        }

        

    }
}