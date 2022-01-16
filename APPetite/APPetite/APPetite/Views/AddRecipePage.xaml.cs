using APPetite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipePage : ContentPage
    {
        public AddRecipePage()
        {
            InitializeComponent();
        }

        private async void GoBackPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        public async void ChooseImage(object sender, EventArgs e)
        {
            var img = await MediaPicker.PickPhotoAsync();

            if (img != null)
            {
                string imageName = img.FileName;
                image_name.Text = imageName;
                image_name.IsVisible = true;

                if (image_link.IsVisible)
                {
                    image_link.IsVisible = false;
                }
            }
        }

        public void GetImage(object sender, EventArgs e)
        {
            image_link.IsVisible = true;
        }

        public void AddRecipe(object sender, EventArgs e)
        {
            Recipe rep = new Recipe();
            rep.cookingTime = recipe_time.Text;
            rep.difficulty = recipe_hard.Text;
            rep.imageSource = image_link.Text;
            rep.ingredient = recipe_ingredient.Text.Split('+').ToList();
            rep.name = recipe_name.Text;
            rep.numberPerson = recipe_number.Text;
            rep.step = recipe_step.Text.Split('+').ToList();
            rep.likes = 0;

        }

        private void checkToEnable()
        {
            add_recipe_button.IsEnabled = false;
            if (!string.IsNullOrEmpty(recipe_hard.Text) && !string.IsNullOrEmpty(recipe_ingredient.Text) &&
                !string.IsNullOrEmpty(recipe_name.Text) && !string.IsNullOrEmpty(recipe_number.Text) &&
                !string.IsNullOrEmpty(recipe_step.Text) && !string.IsNullOrEmpty(recipe_time.Text))
            {
                add_recipe_button.IsEnabled = true;
            }
        }

        void entryTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            checkToEnable();
        }
    }
}