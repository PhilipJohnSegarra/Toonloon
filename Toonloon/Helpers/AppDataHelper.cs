using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toonloon.Helpers
{
    public class AppDataHelper
    {
        public FirebaseFirestore GetFirestore()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseFirestore database;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                   .SetProjectId("toonloon-cbfce")
                   .SetApplicationId("1:1048209868140:android:e26122936e0860df831f49")
                   .SetApiKey("AIzaSyBS3dNGXx3vCzrc15mvJOM3d7Nptfp4jQw")
                   .SetStorageBucket("toonloon-cbfce.appspot.com")
                   .Build();
                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseFirestore.GetInstance(app);

            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);


            }
            return database;
        }
        public FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth mAuth;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                   .SetProjectId("toonloon-cbfce")
                   .SetApplicationId("1:1048209868140:android:e26122936e0860df831f49")
                   .SetApiKey("AIzaSyBS3dNGXx3vCzrc15mvJOM3d7Nptfp4jQw")
                   .SetStorageBucket("toonloon-cbfce.appspot.com")
                   .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                mAuth = FirebaseAuth.Instance;

            }
            else
            {
                mAuth = FirebaseAuth.Instance;


            }
            return mAuth;
        }
    }
}