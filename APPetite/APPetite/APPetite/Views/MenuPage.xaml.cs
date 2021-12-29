using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void LogoutApp(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(OpenPage)}");
        }

        private async void OpenAboutUsPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(AboutUsPage)}");
        }

        private async void test(object sender, EventArgs e)
        {
            //var ok = await new RecipeService().GetRecipeAllList();
            //concac.Source = Path.Combine(FileSystem.CacheDirectory, "1.png");

            //string text = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp.txt"));
            //RootObject recipe = JsonConvert.DeserializeObject<RootObject>(text);
        }
    }
}