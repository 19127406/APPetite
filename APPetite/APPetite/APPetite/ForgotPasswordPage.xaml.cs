using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void Go_back_clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void checkToEnable()
        {
            ResetPasswordButton.IsEnabled = false;
            ResetPasswordButton.Background = Brush.DarkGray;
            if (!string.IsNullOrEmpty(forgotEmailEntry.Text))
            {
                ResetPasswordButton.IsEnabled = true;
                ResetPasswordButton.Background = Brush.LightGray;
            }
        }

        void entryTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            checkToEnable();
        }

        private void Reset_password_clicked(object sender, EventArgs e)
        {

        }
    }
}