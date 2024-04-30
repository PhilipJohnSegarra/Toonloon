using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Toonloon.Helpers
{
    public class GetImagesOnline
    {
        public ImageView GetImage(ImageView imgview, string url)
        {
            
            using (var webClient = new WebClient())
            {
                webClient.DownloadDataAsync(new Uri(url));
                webClient.DownloadDataCompleted += (sender , e) => {
                    if (e.Error == null)
                    {
                        // Convert downloaded data to a Bitmap
                        Bitmap bitmap = BitmapFactory.DecodeByteArray(e.Result, 0, e.Result.Length);

                        // Set the Bitmap as the source for the ImageView
                        imgview.SetImageBitmap(bitmap);
                    }
                    else
                    {
                        // Handle error
                        Toast.MakeText(Application.Context,"Error downloading image: " + e.Error.Message, ToastLength.Short).Show();
                        return;
                    }
                };
            }

            return imgview;
        }
    }
}