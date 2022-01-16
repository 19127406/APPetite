using APPetite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    public partial class MyRecipePage : ContentPage
    {
        MyRecipeView myRecipe = new MyRecipeView();
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
                ingredient = value.Split('+').ToList();
            }
        }
        public List<string> step { get; set; }
        public string steps
        {
            get { return null; }
            set
            {
                step = value.Split('+').ToList();
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
        public MyRecipePage()
        {
            InitializeComponent();
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

        public async void OpenAddrecipe(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(AddRecipePage)}");
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await myRecipe.getUserInfo();
            if (name != null)
            {
                myRecipe.rep.cookingTime = cookingTime;
                myRecipe.rep.difficulty = difficulty;
                myRecipe.rep.imageSource = imageSource;
                myRecipe.rep.ingredient = ingredient;
                myRecipe.rep.likes = likes;
                myRecipe.rep.name = name;
                myRecipe.rep.numberPerson = numberPerson;
                myRecipe.rep.step = step;
                await myRecipe.AddRecipe();

                name = null;
            }

            BindingContext = myRecipe;
        }
    }
}