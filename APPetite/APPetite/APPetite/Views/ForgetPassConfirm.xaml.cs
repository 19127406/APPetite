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
    public partial class ForgetPassConfirm : ContentPage
    {
        public ForgetPassConfirm()
        {
            InitializeComponent();
        }

        private async void BackToOpenPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(OpenPage)}");
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}