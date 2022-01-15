using APPetite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace APPetite.ViewModels
{
    public class CategoryView : INotifyPropertyChanged
    {
        public static string json;
        public Data data { get; set; } = new Data();
        public ObservableCollection<Recipe> recipe { get; set; } = new ObservableCollection<Recipe>();
        public string numberRecipe { get; set; }
        public string typeRecipe { get; set; }

        public void AddCategory()
        {
            recipe.Clear();
            data = JsonConvert.DeserializeObject<Data>(json);
            typeRecipe = data.type;
            foreach (var meal in data.list)
            {
                recipe.Add(meal);
            }
            numberRecipe = recipe.Count.ToString();
            numberRecipe += " công thức";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
