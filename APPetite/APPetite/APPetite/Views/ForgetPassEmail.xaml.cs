using APPetite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
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
            Email email = new Email();
            if (!IsValidEmail(email_forgetpass.Text))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Email Address", "Please enter correct Email Address", "OK");
            }
            else
            {
                email.send_email(email_forgetpass.Text, "Reset password");
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
    }
}