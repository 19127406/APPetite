using APPetite.ViewModels;
using APPetite.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static FirebaseClient fc = new FirebaseClient("https://projectse-21-22-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }

        public async void Sign_in_clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text,
                password = passwordEntry.Text;


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                var user = await FirebaseHelper.GetUser(username);
                //firebase return null valuse if user data not found in database    
                if (user != null)
                    if (username == user.Username && password == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        await Navigation.PushAsync(new Home());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                    }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
                }
            }
        }

        public async void Sign_up_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        public async void Forgot_password_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}