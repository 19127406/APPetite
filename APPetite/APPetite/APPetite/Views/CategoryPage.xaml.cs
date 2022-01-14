using APPetite.Models;
using APPetite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            Button btn = (Button)sender;
            var buttonName = btn.ClassId;
            var json = await FirebaseStorageHelper.Download_Json(buttonName);
            await Shell.Current.GoToAsync($"{nameof(CategoryDetailPage)}?json={json}");
        }
    }
}