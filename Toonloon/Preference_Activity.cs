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
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Toonloon
{
    [Activity(Label = "Preference_Activity")]
    public class Preference_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Preference);
            
            Button toHome = FindViewById<Button>(Resource.Id.continueP);
            Button toSkip = FindViewById<Button>(Resource.Id.Skip);

            toHome.Click += (sender, e) =>
            {
                //-> Home
                Intent intent = new Intent(this, typeof(Home_Activity));
                StartActivity(intent);
            };

            toSkip.Click += (sender, e) =>
            {
                //-> Home
                Intent intent = new Intent(this, typeof(Home_Activity));
                StartActivity(intent);
            };
        }
        static async Task AuthenticateAndFetch()
        {
            try
            {
                var creds = new
                {
                    grant_type = "password",
                    username = "Anastasius55",
                    password = "toonloon123!",
                    client_id = "personal-client-b2d9cc7e-c6ce-40b4-b755-ce21455b9257-0b5f0fe4",
                    client_secret = "Tt09iMHJd9THrr5iAU8hIpfxUY4qkWmq"
                };

                var client = new HttpClient();
                var jsonContent = JsonConvert.SerializeObject(creds);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://auth.mangadex.org/realms/mangadex/protocol/openid-connect/token", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseContent);
                    var accessToken = data.access_token;
                    var refreshToken = data.refresh_token;

                    Console.WriteLine($"Access Token: {accessToken}");
                    Console.WriteLine($"Refresh Token: {refreshToken}");

                    // Now you can make authenticated requests to the MangaDex API using the access_token
                    // For example:
                    // var mangaResponse = await client.GetAsync("https://api.mangadex.org/manga", new System.Threading.CancellationToken());
                    // var mangaData = await mangaResponse.Content.ReadAsStringAsync();
                    // Console.WriteLine($"Manga Data: {mangaData}");
                }
                else
                {
                    Console.WriteLine($"Failed to authenticate: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}