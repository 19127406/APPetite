using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        public async void OpenCategoryDetail(object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            //btn.id
            await Shell.Current.GoToAsync($"/{nameof(CategoryDetailPage)}");
        }
    }
}