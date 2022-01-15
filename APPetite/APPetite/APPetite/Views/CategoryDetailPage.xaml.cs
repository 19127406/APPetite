using APPetite.Models;
using APPetite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[QueryProperty(nameof(json), nameof(json))]
    public partial class CategoryDetailPage : ContentPage
    {
        //public string json { get; set; }

        private CategoryView categoryView = new CategoryView();

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
            categoryView.AddCategory();
            BindingContext = categoryView;
        }
    }
}