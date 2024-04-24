using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toonloon.EventListeners;
using Toonloon.Helpers;

namespace Toonloon
{
    [Activity(Label = "SignUp_Activity")]
    public class SignUp_Activity : Activity
    {


        EditText username, email, password;
        Button signup, buttongoogle, btnfacebook, buttontwitter;
        TextView login;

        FirebaseFirestore database;
        FirebaseAuth mAuth;
        TaskCompletionListener taskCompletionListeners = new TaskCompletionListener();
        AppDataHelper appDataHelper = new AppDataHelper();



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.SignUp);

            //


            username = FindViewById<EditText>(Resource.Id.username);
            email = FindViewById<EditText>(Resource.Id.email);
            password = FindViewById<EditText>(Resource.Id.pass);

            buttongoogle = FindViewById<Button>(Resource.Id.buttongoogle);
            btnfacebook = FindViewById<Button>(Resource.Id.buttonfb);
            buttontwitter = FindViewById<Button>(Resource.Id.buttontwt);


            database = GetFirestore();
            mAuth = FirebaseAuth.Instance;







            Button login = FindViewById<Button>(Resource.Id.loginS);
            Button signup = FindViewById<Button>(Resource.Id.buttonsignup);
            EditText passEditText = FindViewById<EditText>(Resource.Id.pass);
            ImageButton toggleButton = FindViewById<ImageButton>(Resource.Id.togglePassword);

            bool passwordVisible = false;



            FirebaseFirestore GetFirestore()
            {
                var app = FirebaseApp.InitializeApp(Application.Context);
                FirebaseFirestore database;

                if (app == null)
                {
                    var options = new FirebaseOptions.Builder()
                       .SetProjectId("toonloon-cbfce")
                       .SetApplicationId("toonloon-cbfce")
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















            toggleButton.Click += (sender, e) =>
            {
                if (passwordVisible)
                {
                    passEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
                    toggleButton.SetImageResource(Resource.Drawable.design_ic_visibility);
                }
                else
                {
                    passEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationVisiblePassword;
                    toggleButton.SetImageResource(Resource.Drawable.design_ic_visibility_off);
                }
                passwordVisible = !passwordVisible;
            };


            login.Click += (sender, e) =>
            {
                // -> login page
                Intent intent = new Intent(this, typeof(Signin_Activity));
                StartActivity(intent);
            };


            bool ContainsSpecialCharacter(string password)
            {
                string specialCharacters = "!@#$%^&*()-_=+[]{}|;:'\",.<>/?";
                return password.Any(char.IsLetterOrDigit) && password.Any(specialCharacters.Contains);
            }








            signup.Click += (sender, e) =>
            {
                // sign up -> Verification
                // Did some changes over here. - Chelo XD
                if (username.Text == "" || email.Text == "" || password.Text == "")
                {
                    Toast.MakeText(this, "Please fill-up the blanks!", ToastLength.Short).Show();
                }

                else if (password.Text.Length < 8 || password.Text.Length > 16)
                {
                    Toast.MakeText(this, "Password is invalid 8 to 16 characters only", ToastLength.Short).Show();
                }
                else if (!ContainsSpecialCharacter(password.Text))
                {
                    Toast.MakeText(this, "Password must contain at least one special character", ToastLength.Short).Show();
                }
                else
                {
                    mAuth.CreateUserWithEmailAndPassword(email.Text, password.Text).AddOnSuccessListener(this,
                     taskCompletionListeners).AddOnFailureListener(this,
                   taskCompletionListeners);

                    taskCompletionListeners.Success += (success, args) =>
                    {
                        HashMap userMap = new HashMap();
                        userMap.Put("username", username.Text);
                        userMap.Put("email", email.Text);
                        userMap.Put("password", password.Text);
                        DocumentReference userReference = database.Collection("UserDetails").Document(mAuth.CurrentUser.Uid);
                        userReference.Set(userMap);
                        //progress.ProgressHide();
                        Toast.MakeText(this, "Registered Successfully", ToastLength.Short).Show();
                        Intent intent = new Intent(this, typeof(Signin_Activity));
                        StartActivity(intent);

                    };
                    taskCompletionListeners.Failure += (failure, args) =>
                    {

                        Toast.MakeText(this, "Please register your account." + args.Cause, ToastLength.Short).Show();
                    };
                };

            };



        }
    }
}