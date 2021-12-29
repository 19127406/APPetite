using APPetite.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPassEmail : ContentPage
    {
        public ForgetPassEmail()
        {
            InitializeComponent();
        }

        private async void SendConfirmEmail(object sender, EventArgs e)
        {
            if (!Email.IsValidEmail(email_forgetpass.Text))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Email Address", "Please enter correct Email Address", "OK");
            }
            else
            {
                Email.send_email(email_forgetpass.Text, "Reset password");
                await Shell.Current.GoToAsync($"/{nameof(ForgetPassConfirm)}");
            }
        }

        private void checkToEnable()
        {
            ContinueButton.IsEnabled = false;
            //ContinueButton.Background = Brush.DarkGray;
            if (!string.IsNullOrEmpty(email_forgetpass.Text))
            {
                ContinueButton.IsEnabled = true;
                //ContinueButton.Background = Brush.LightGray;
            }
        }

        void entryTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            checkToEnable();
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}