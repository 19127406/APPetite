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