using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APPetite.ViewModels;
using System.Collections.Generic;
using APPetite.Models;
using System.Linq;
using System.Net;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public Recipe rep = new Recipe();
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
            var args = (TappedEventArgs)e;
            var myObject = args.Parameter;

            rep = (Recipe)myObject;
            string ingredients = "";
            string steps = ""; ;
            foreach (var ingredient in rep.ingredient)
            {
                if (ingredient == rep.ingredient[rep.ingredient.Count - 1])
                {
                    ingredients += ingredient;
                    break;
                }
                ingredients += ingredient + '~';
            }
            foreach (var step in rep.step)
            {
                if (step == rep.step[rep.step.Count - 1])
                {
                    steps += step;
                    break;
                }
                steps += step + "~";
            }

            var url = WebUtility.UrlEncode(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(rep.imageSource)));

            await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?name={rep.name}&ingredient={ingredients}&step={steps}&imageSource={url}&numberPerson={rep.numberPerson}&cookingTime={rep.cookingTime}&difficulty={rep.difficulty}&likes={rep.likes}");
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

        public async void OpenSearchPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(SearchPage)}");
        }
    }
}