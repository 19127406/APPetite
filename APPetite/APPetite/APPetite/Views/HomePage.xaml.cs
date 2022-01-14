using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APPetite.ViewModels;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public async void Refresh(object sender, EventArgs e)
        {
            await Task.Delay(3000);
        }

        public async void OpenRecipeDetail(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(RecipeDetailPage)}");
        }
    }
}