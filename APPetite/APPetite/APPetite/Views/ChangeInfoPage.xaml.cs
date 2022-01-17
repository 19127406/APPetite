using APPetite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeInfoPage : ContentPage
    {
        public ChangeInfoPage()
        {
            InitializeComponent();
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
        private async void ChangeInfo(object sender, EventArgs e)
        {
            if (pass_change.Text.Length < 8)
            {
                await App.Current.MainPage.DisplayAlert("Invalid Password", "", "OK");
            }
            else if (!string.IsNullOrEmpty(email_change.Text))
            {
                if (!Email.IsValidEmail(email_change.Text))
                    await App.Current.MainPage.DisplayAlert("Invalid Email Address", "Please enter correct Email Address", "OK");
                else
                {
                    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CurrentAccount.txt");
                    var temp = File.ReadAllText(fileName);
                    var user = await FirebaseAccountHelper.GetUserByUsername(temp);
                    var result = await FirebaseAccountHelper.UpdateUser(user.Username, email_change.Text, pass_change.Text, user.BackupPass, user.RecipeJsonString);
                }
            }
            else
            {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CurrentAccount.txt");
                var temp = File.ReadAllText(fileName);
                var user = await FirebaseAccountHelper.GetUserByUsername(temp);
                var result = await FirebaseAccountHelper.UpdateUser(user.Username, user.Email, pass_change.Text, user.BackupPass, user.RecipeJsonString);
            }
        }
        private void checkToEnable()
        {
            save_change.IsEnabled = false;
            if (!string.IsNullOrEmpty(pass_change.Text) && !string.IsNullOrEmpty(confirm_pass_change.Text) &&
                pass_change.Text.Equals(confirm_pass_change.Text))
            {
                save_change.IsEnabled = true;
            }
        }

        void entryTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            checkToEnable();
        }
    }
}