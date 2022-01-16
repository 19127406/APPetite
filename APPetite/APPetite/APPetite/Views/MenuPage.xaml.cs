﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPetite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void LogoutApp(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(OpenPage)}");
        }

        private async void OpenAboutUsPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(AboutUsPage)}");
        }

        private async void OpenChangeInfo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(ChangeInfoPage)}");
        }
    }
}