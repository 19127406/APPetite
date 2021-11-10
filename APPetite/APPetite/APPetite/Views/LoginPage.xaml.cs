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
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }

        public async void Sign_in_clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text,
                password = passwordEntry.Text;


            // temp for register account later
            //FirebaseClient fc = new FirebaseClient("https://projectse-21-22-default-rtdb.asia-southeast1.firebasedatabase.app/");
            //var check = await fc
            //    .Child("Account")
            //    .PostAsync(new Account() { Username = username, Password = password });
            //





            await Navigation.PushAsync(new AboutUs());
        }

        public async void Sign_up_clicked(object sender, EventArgs e)
        {

        }

        public async void Forgot_password_clicked(object sender, EventArgs e)
        {

        }
    }
}