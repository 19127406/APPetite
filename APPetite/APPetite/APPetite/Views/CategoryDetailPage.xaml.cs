using APPetite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(json), nameof(json))]
    public partial class CategoryDetailPage : ContentPage
    {
        public string json { get; set; }
        public Data data { get; set; } = new Data();
        public ObservableCollection<Recipe> recipe { get; set; } = new ObservableCollection<Recipe>();
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
            await Shell.Current.GoToAsync($"/{nameof(RecipeDetailPage)}");
        }
        protected override void OnAppearing() 
        {
            base.OnAppearing();
            recipe.Clear();
            data = JsonConvert.DeserializeObject<Data>(json);
            foreach(var meal in data.list)
            {
                recipe.Add(meal);
            }
        }
    }
}