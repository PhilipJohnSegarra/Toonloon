using Android.Widget;
using AndroidX.AppCompat.App;
using AlertDialog = Android.App.AlertDialog;
using Android.Views;
using Android.App;
using Android.OS;
using Android.Text.Style;
using Android.Text;
using Android.Content;
using System;
using static Android.Content.Res.Resources;
using Xamarin.Essentials;
using Xamarin.Protobuf.Lite;

namespace Toonloon
{
    [Activity(Label = "Toonloon", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private bool termsClicked = false;
        private bool privacyClicked = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // 
            TextView termsTextView = FindViewById<TextView>(Resource.Id.Terms);
            CheckBox termsCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxTerms);
            TextView privacyTextView = FindViewById<TextView>(Resource.Id.Privacy);
            CheckBox privacyCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxPrivacy);
            Button continueButton = FindViewById<Button>(Resource.Id.buttonContinue);

            continueButton.Click += (sender, e) =>
            {
                // Check if both checkboxes are checked
                if (termsCheckBox.Checked && privacyCheckBox.Checked)
                {
                    // Both checkboxes are checked, allow the user to continue
                    Intent intent = new Intent(this, typeof(SignUp_Activity));
                    StartActivity(intent);
                }
                else
                {
                    // Display a message indicating that both checkboxes must be checked
                    Toast.MakeText(this, "Please accept both Terms and Conditions and Privacy Policy to continue", ToastLength.Short).Show();
                }
            };


            termsTextView.Click += (sender, e) =>
            {
                if (!termsClicked)
                {
                    // Apply underline effect only when the text is clicked for the first time
                    SpannableString content = new SpannableString(termsTextView.Text);
                    content.SetSpan(new UnderlineSpan(), 0, content.Length(), 0);
                    termsTextView.TextFormatted = content;
                    termsClicked = true;
                }

                ShowTermsDialog();
            };

            termsCheckBox.CheckedChange += (sender, e) =>
            {
                if (e.IsChecked)
                {
                    // If checkbox is checked, remove underline and disable text click
                    termsTextView.Text = "Accept Terms and Conditions";
                    termsTextView.Clickable = true;
                    termsTextView.SetTextColor(Android.Graphics.Color.DarkOrange);
                }
                else
                {
                    // If checkbox is unchecked, re-enable text click
                    termsTextView.Text = "Accept Terms and Conditions";
                    termsTextView.Clickable = true;
                    termsTextView.SetTextColor(Android.Graphics.Color.Sienna);
                }
            };

            void ShowTermsDialog()
            {
                // Inflate custom layout for dialog buttons
                View dialogButtonsView = LayoutInflater.Inflate(Resource.Layout.dialog_buttons, null);

                // Retrieve the buttons from the custom layout
                Button positiveButton = dialogButtonsView.FindViewById<Button>(Resource.Id.positiveButton);
                Button negativeButton = dialogButtonsView.FindViewById<Button>(Resource.Id.negativeButton);

                // Create AlertDialog object
                AlertDialog alertDialog = null;

                // Show dialog here
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Terms and Conditions");
                builder.SetMessage("App terms and conditions text goes here. \n\n Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                    "\n\n sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum neque egestas congue quisque egestas. " +
                    "\n\n Rhoncus dolor purus non enim. Tempus imperdiet nulla malesuada pellentesque elit eget. Vehicula ipsum a arcu cursus " +
                    "\n\n vitae congue mauris rhoncus aenean. Tellus id interdum velit laoreet. Cras pulvinar mattis nunc sed blandit libero " +
                    "\n\n volutpat sed cras. Est sit amet facilisis magna etiam tempor orci. Aliquam purus sit amet luctus. Quis enim lobortis " +
                    "\n\n scelerisque fermentum dui faucibus. Donec massa sapien faucibus et molestie. Pellentesque habitant morbi tristique " +
                    "senectus.");


                builder.SetView(dialogButtonsView); // custom layout for dialog buttons

                // Set click listeners for the custom buttons
                positiveButton.Click += (sender, args) =>
                {
                    if (alertDialog != null)
                    {
                        // User clicked Agree
                        // Perform any necessary action here
                        termsCheckBox.Checked = true; // Check the checkbox
                        alertDialog.Dismiss(); // Dismiss the dialog
                    }
                };

                negativeButton.Click += (sender, args) =>
                {
                    if (alertDialog != null)
                    {
                        // User clicked Disagree
                        // Perform any necessary action here
                        termsCheckBox.Checked = false; // Uncheck the checkbox
                        alertDialog.Dismiss(); // Dismiss the dialog
                    }
                };

                alertDialog = builder.Create(); // Create AlertDialog object

                // Show the AlertDialog
                alertDialog.Show();

            }

            privacyTextView.Click += (sender, e) =>
            {
                if (!privacyClicked)
                {
                    // Apply underline effect only when the text is clicked for the first time
                    SpannableString content = new SpannableString(privacyTextView.Text);
                    content.SetSpan(new UnderlineSpan(), 0, content.Length(), 0);
                    privacyTextView.TextFormatted = content;
                    privacyClicked = true;
                }

                ShowPrivacyDialog();
            };

            privacyCheckBox.CheckedChange += (sender, e) =>
            {
                if (e.IsChecked)
                {
                    // If checkbox is checked, remove underline and disable text click
                    privacyTextView.Text = "Accept Privacy Policy";
                    privacyTextView.Clickable = true;
                    privacyTextView.SetTextColor(Android.Graphics.Color.DarkOrange);
                }
                else
                {
                    // If checkbox is unchecked, re-enable text click
                    privacyTextView.Text = "Accept Privacy Policy";
                    privacyTextView.Clickable = true;
                    privacyTextView.SetTextColor(Android.Graphics.Color.Sienna);
                }
            };

            void ShowPrivacyDialog()
            {
                // Inflate custom layout for dialog buttons
                View dialogButtonsView = LayoutInflater.Inflate(Resource.Layout.dialog_buttons, null);

                // Retrieve the buttons from the custom layout
                Button positiveButton = dialogButtonsView.FindViewById<Button>(Resource.Id.positiveButton);
                Button negativeButton = dialogButtonsView.FindViewById<Button>(Resource.Id.negativeButton);

                // Create AlertDialog object
                AlertDialog alertDialog = null;

                // Show dialog here
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Privavy Policy");
                builder.SetMessage("App Privacy Policy text goes here. \n\n Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                    "\n\n sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum neque egestas congue quisque egestas. " +
                    "\n\n Rhoncus dolor purus non enim. Tempus imperdiet nulla malesuada pellentesque elit eget. Vehicula ipsum a arcu cursus " +
                    "\n\n vitae congue mauris rhoncus aenean. Tellus id interdum velit laoreet. Cras pulvinar mattis nunc sed blandit libero " +
                    "\n\n volutpat sed cras. Est sit amet facilisis magna etiam tempor orci. Aliquam purus sit amet luctus. Quis enim lobortis " +
                    "\n\n scelerisque fermentum dui faucibus. Donec massa sapien faucibus et molestie. Pellentesque habitant morbi tristique " +
                    "senectus.");

                builder.SetView(dialogButtonsView); // custom layout for dialog buttons

                // Set click listeners for the custom buttons
                positiveButton.Click += (sender, args) =>
                {
                    if (alertDialog != null)
                    {
                        // User clicked Agree
                        // Perform any necessary action here
                        privacyCheckBox.Checked = true; // Check the checkbox
                        alertDialog.Dismiss(); // Dismiss the dialog
                    }
                };

                negativeButton.Click += (sender, args) =>
                {
                    if (alertDialog != null)
                    {
                        // User clicked Disagree
                        // Perform any necessary action here
                        privacyCheckBox.Checked = false; // Uncheck the checkbox
                        alertDialog.Dismiss(); // Dismiss the dialog
                    }
                };
                alertDialog = builder.Create(); // Create AlertDialog object

                // Show the AlertDialog
                alertDialog.Show();

            }
        }

    }
}