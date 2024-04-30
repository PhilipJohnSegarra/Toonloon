using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Firestore.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toonloon.EventListeners;
using Toonloon.Helpers;

namespace Toonloon
{
    [Activity(Label = "Signin_Activity")]
    public class Signin_Activity : Activity
    {
        TextView signup;
        EditText username, password,passEditText;
        Button signin,forgotpass;
        FirebaseFirestore database;
        ImageButton toggleButton;
        FirebaseAuth mAuth;
        TaskCompletionListener taskCompletionListeners = new TaskCompletionListener();
        AppDataHelper appDataHelper = new AppDataHelper();
        bool passwordVisible = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignIn);

            //
            username = FindViewById<EditText>(Resource.Id.usernameS);
            password = FindViewById<EditText>(Resource.Id.pass);

            Button forgotpass = FindViewById<Button>(Resource.Id.forgotpass);
            Button Login = FindViewById<Button>(Resource.Id.buttonLogin);
            EditText passEditText = FindViewById<EditText>(Resource.Id.pass);
            ImageButton toggleButton = FindViewById<ImageButton>(Resource.Id.togglePassword);


            mAuth = appDataHelper.GetFirebaseAuth();
            toggleButton.Click += ToggleButton_Click;
            forgotpass.Click += Forgotpass_Click;
            Login.Click += Login_Click;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //-> preference
            //Did some changes over here   - CheloXD 
            mAuth.SignInWithEmailAndPassword(username.Text, password.Text).AddOnSuccessListener
           (taskCompletionListeners).AddOnFailureListener(taskCompletionListeners);

            taskCompletionListeners.Success += (success, args) =>
            {

                Toast.MakeText(this, "Welcome To ToonLoon", ToastLength.Short).Show();
                //Intent intent = new Intent(this, typeof(Preference_Activity));
                //StartActivity(intent);

            };            
            
            taskCompletionListeners.Failure += (failure, args) =>
            {

                Toast.MakeText(this, "Incorrect, please try again." + args.Cause, ToastLength.Short).Show();
            };
        }

        private void Forgotpass_Click(object sender, EventArgs e)
        {
            // -> acc retrieval
                   Intent intent = new Intent(this, typeof(AccRetrieval_Activity));
                    StartActivity(intent);
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            //if (passwordVisible)
            //{
            //    passEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
            //    toggleButton.SetImageResource(Resource.Drawable.design_ic_visibility);
            //}
            //else
            //{
            //    passEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationVisiblePassword;
            //    toggleButton.SetImageResource(Resource.Drawable.design_ic_visibility_off);
            //}
            //passwordVisible = !passwordVisible;

        }


            }
        }
    
