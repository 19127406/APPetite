using APPetite.Models;
using APPetite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Web;
using System.Net;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[QueryProperty(nameof(json), nameof(json))]
    public partial class CategoryDetailPage : ContentPage
    {
        //public string json { get; set; }

        private CategoryView categoryView = new CategoryView();
        public Recipe rep = new Recipe();

        public CategoryDetailPage()
        {
            InitializeComponent();
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        public async void OpenRecipeDetail(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var myObject = args.Parameter;

            //Frame frame = (Frame)sender;
            //TapGestureRecognizer tap = (TapGestureRecognizer)frame.GestureRecognizers[0];
            //var test = tap.CommandParameter;

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
            //
            var url = WebUtility.UrlEncode(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(rep.imageSource)));
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?name={rep.name}&ingredient={ingredients}&step={steps}&imageSource={url}&numberPerson={rep.numberPerson}&cookingTime={rep.cookingTime}&difficulty={rep.difficulty}&likes={rep.likes}");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            categoryView.AddCategory();
            BindingContext = categoryView;
        }

        public void favoriteButtonClick(object sender, EventArgs e)
        {
            ImageButton img_btn = (ImageButton)sender;

            if (img_btn.Source is FileImageSource)
            {
                FileImageSource fileImage = (FileImageSource)img_btn.Source;
                img_btn.Source = fileImage.File == "favorite.png" ? "favorite_border.png" : "favorite.png";
            }
        }
    }
}