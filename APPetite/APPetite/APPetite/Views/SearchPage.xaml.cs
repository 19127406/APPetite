using APPetite.Models;
using APPetite.Services;
using APPetite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        MyRecipeView my_search = new MyRecipeView();
        public ObservableCollection<Data> data { get; set; }
        public SearchPage()
        {
            InitializeComponent();
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        public async void SearchRecipe(object sender, EventArgs e)
        {
            my_search.recipe.Clear();
            RecipeService service = new RecipeService();
            var result = await service.GetRecipeAllList();
            if (result != null)
                data = new ObservableCollection<Data>(result);
            foreach (var list in data)
            {
                foreach (var recipe in list.list)
                {
                    if (recipe.name.Contains(search_key.Text))
                    {
                        my_search.recipe.Add(recipe);
                    }
                }
            }

            var allAccount = await FirebaseAccountHelper.GetAllUser();
            foreach (var account in allAccount)
            {
                foreach (var recipe in JsonConvert.DeserializeObject<List<Recipe>>(account.RecipeJsonString))
                {
                    if (recipe.name.Contains(search_key.Text))
                    {
                        my_search.recipe.Add(recipe);
                    }
                }
            }

            BindingContext = my_search;
        }

        public async void OpenRecipeDetail(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var myObject = args.Parameter;

            //Frame frame = (Frame)sender;
            //TapGestureRecognizer tap = (TapGestureRecognizer)frame.GestureRecognizers[0];
            //var test = tap.CommandParameter;

            Recipe rep = (Recipe)myObject;
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
    }
}