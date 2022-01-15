using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APPetite.ViewModels;
using System.Collections.Generic;
using APPetite.Models;
using System.Linq;

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

        public void favoriteButtonClick(object sender, EventArgs e)
        {
            ImageButton img_btn = (ImageButton)sender;
            
            if(img_btn.Source is FileImageSource)
            {
                FileImageSource fileImage = (FileImageSource)img_btn.Source;
                img_btn.Source = fileImage.File == "favorite.png" ? "favorite_border.png" : "favorite.png";
            }
        }
    }
}