using APPetite.Models;
using APPetite.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APPetite.ViewModels
{
    public class RecipeView : INotifyPropertyChanged
    {
        protected RecipeService service = new RecipeService();

        public List<Data> data { get; set; }

        public List<Recipe> randomData { get; set; }

        public ICommand GetRecipeCommand { get; set; }

        public bool IsRunning { get; set; }

        public RecipeView()
        {
            randomData = new List<Recipe>();
            GetRecipeCommand = new Command(async () => await GetRecipe());
            GetRecipeCommand.Execute(null);
        }

        private async Task GetRecipe()
        {
            IsRunning = true;

            var result = await service.GetRecipeAllList();
            if (result != null)
                data = new List<Data>(result);

            IsRunning = false;

            Random rnd = new Random();
            foreach (var list in data)
            {
                randomData.Add(list.list[rnd.Next(0, list.list.Count)]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}