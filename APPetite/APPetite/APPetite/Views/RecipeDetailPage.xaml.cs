using System;
using System.Collections.Generic;
using APPetite.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(name), nameof(name))]
    [QueryProperty("ingredients", "ingredient")]
    [QueryProperty("steps", "step")]
    [QueryProperty("imagesource", "imageSource")]
    [QueryProperty(nameof(numberPerson), nameof(numberPerson))]
    [QueryProperty(nameof(cookingTime), nameof(cookingTime))]
    [QueryProperty(nameof(difficulty), nameof(difficulty))]
    [QueryProperty(nameof(likes), nameof(likes))]
    public partial class RecipeDetailPage : ContentPage
    {
        public string name
        {
            get;
            set;
        }
        public List<string> ingredient { get; set; }
        public string ingredients
        {
            get { return null; }
            set
            {
                ingredient = value.Split('~').ToList();
            }
        }
        public List<string> step { get; set; }
        public string steps
        {
            get { return null; }
            set
            {
                step = value.Split('~').ToList();
            }
        }
        public string imageSource { get; set; }
        public string imagesource
        {
            get { return imageSource; }
            set 
            {
                var url = Uri.UnescapeDataString(value);
                var base64EncodedBytes = System.Convert.FromBase64String(url);
                imageSource = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
        }
        public string numberPerson
        {
            get;
            set;
        }
        public string cookingTime
        {
            get;
            set;
        }
        public string difficulty
        {
            get;
            set;
        }
        public int likes
        {
            get;
            set;
        }
        public RecipeDetailPage()
        {
            InitializeComponent();
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
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