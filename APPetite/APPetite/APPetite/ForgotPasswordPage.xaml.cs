using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APPetite.ViewModels;
using APPetite.Models;

namespace APPetite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
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

        private async void Reset_password_clicked(object sender, EventArgs e)
        {
            Email email = new Email();
            if (!IsValidEmail(forgotEmailEntry.Text))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Email Address", "", "OK");
            }
            else
            {
                email.send_email(forgotEmailEntry.Text, "Reset password");
                await App.Current.MainPage.DisplayAlert("Check your email", "We've sent you a password reset email", "OK");
            }
        }

        public async void Update_password(string emailAddress, string new_password)
        {
            var user = await FirebaseHelper.GetUserByEmail(emailAddress);
            var success = await FirebaseHelper.UpdateUser(user.Username, user.Email, new_password);
        }
    }
}