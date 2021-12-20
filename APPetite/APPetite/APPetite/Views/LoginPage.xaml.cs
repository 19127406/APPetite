using APPetite.ViewModels;
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
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OpenForgetPassPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(ForgetPassEmail)}");
        }

        private async void LoginApp(object sender, EventArgs e)
        {
            string username = username_login.Text,
                password = password_login.Text;


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Username or Password", "Please enter Username and Password", "OK");
            }
            else
            {
                var user = await FirebaseHelper.GetUserByUsername(username);

                if (user != null)
                {
                    if ((username == user.Username || username == user.Email) && (password == user.Password || password == user.BackupPass))
                    {
                        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Incorrect Password", "The Password you entered is incorrect. Please try again.", "OK");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Failed", "Your Email or Password is incorrect.\nPlease try again", "OK");
                }
            }
            
        }
    }
}