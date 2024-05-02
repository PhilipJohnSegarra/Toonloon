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
    [Activity(Label = "ReadingLayoutActivity")]
    public class ReadingLayoutActivity : AppCompatActivity
    {
        LinearLayout ReadingLayout;
        MockData MD = new MockData();
        GetImagesOnline gio = new GetImagesOnline();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Reading_Layout);

            ReadingLayout = FindViewById<LinearLayout>(Resource.Id.ReadingLinearLayout);

            var manga = from mangaitem in MD.MangaList
                        where mangaitem.MangaID == Convert.ToInt32(Intent.GetStringExtra("MangaID"))
                        select mangaitem;

            foreach (var imgLink in manga.FirstOrDefault().Chapters)
            {
                var imageview = new ImageView(this)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MatchParent,
                    LinearLayout.LayoutParams.WrapContent)
                };

                gio.GetImage(imageview, imgLink);
                ReadingLayout.AddView(imageview);
            }
        }
    }
}