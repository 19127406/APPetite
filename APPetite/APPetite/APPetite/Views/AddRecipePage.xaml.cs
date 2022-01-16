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
            var img = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Hay chon hinh"
            });

            string imageName = img.FileName;
            image_name.Text = imageName;
            image_name.IsVisible = true;

            if (image_link.IsVisible)
            {
                image_link.IsVisible = false;
            }
        }

        public void GetImage(object sender, EventArgs e)
        {
            image_link.IsVisible = true;
        }

        public void AddRecipe(object sender, EventArgs e)
        {

        }
    }
}