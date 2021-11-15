using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APPetite.ViewModels;
using APPetite.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace APPetite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void Go_back_clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void Sign_up_clicked(object sender, EventArgs e)
        {
            string username = registerUsernameEntry.Text,
                email = registerEmailEntry.Text,
                password = registerPasswordEntry.Text,
                confirmPass = confirmPasswordEntry.Text;

            if (!String.Equals(password, confirmPass))
            {
                confirmAlert.TextColor = Color.Red;
                confirmPasswordEntry.PlaceholderColor = Color.Red;
            }
            else
            {
                var user = await FirebaseHelper.AddUser(username, email, password);
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Sign Up Success", "", "OK");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");
            }
        }

        private void checkToEnable()
        {
            signUpButton.IsEnabled = false;
            signUpButton.Background = Brush.DarkGray;
            if (
                !string.IsNullOrEmpty(registerUsernameEntry.Text) && !string.IsNullOrEmpty(registerPasswordEntry.Text) &&
                !string.IsNullOrEmpty(registerEmailEntry.Text) && !string.IsNullOrEmpty(confirmPasswordEntry.Text)
                )
            {
                signUpButton.IsEnabled = true;
                signUpButton.Background = Brush.LightGray;
            }
        }

        void entryTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            checkToEnable();
        }
    }
}