using APPetite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace APPetite.ViewModels
{
    class MyRecipeView : INotifyPropertyChanged
    {
        public static string username;
        public static string userRecipeJsonString;
        public ObservableCollection<Data> data { get; set; }
        public ObservableCollection<Recipe> recipe { get; set; }

        public MyRecipeView()
        {
            data = new ObservableCollection<Data>(); 
            recipe = new ObservableCollection<Recipe>();
            
            data = JsonConvert.DeserializeObject<ObservableCollection<Data>>(userRecipeJsonString);
        }

        public void Add()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
