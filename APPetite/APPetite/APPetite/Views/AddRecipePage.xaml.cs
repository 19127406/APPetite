using APPetite.Models;
using APPetite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public Recipe rep = new Recipe();
        string image_url = null;
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

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CurrentAccount.txt");
            var temp = File.ReadAllText(fileName);

            image_url = await FirebaseStorageHelper.Upload_File("Image_food/" + temp, img);

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

        public async void AddRecipe(object sender, EventArgs e)
        {
            
            rep.cookingTime = recipe_time.Text;
            rep.difficulty = recipe_hard.Text;
            if (image_url == null)
            {
                rep.imageSource = image_link.Text;
            }
            else
            {
                rep.imageSource = image_url;
            }
            rep.ingredient = recipe_ingredient.Text.Split('+').ToList();
            rep.name = recipe_name.Text;
            rep.numberPerson = recipe_number.Text;
            rep.step = recipe_step.Text.Split('+').ToList();
            rep.likes = 0;

            var url = WebUtility.UrlEncode(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(rep.imageSource)));
            await Shell.Current.GoToAsync($"{nameof(MyRecipePage)}?name={rep.name}&ingredient={recipe_ingredient.Text}&step={recipe_step.Text}&imageSource={url}&numberPerson={rep.numberPerson}&cookingTime={rep.cookingTime}&difficulty={rep.difficulty}&likes={rep.likes}");
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