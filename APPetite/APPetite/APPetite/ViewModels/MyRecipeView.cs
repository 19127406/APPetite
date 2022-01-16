using APPetite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APPetite.ViewModels
{
    class MyRecipeView : INotifyPropertyChanged
    {
        public Recipe rep { get; set; } = new Recipe();

        public ObservableCollection<Recipe> recipe { get; set; } = new ObservableCollection<Recipe>();

        public ICommand GetRecipeCommand { get; set; }

        public async Task getUserInfo()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CurrentAccount.txt");
            var temp = File.ReadAllText(fileName);

            Account user = await FirebaseAccountHelper.GetUserByUsername(temp);
            recipe = JsonConvert.DeserializeObject<ObservableCollection<Recipe>>(user.RecipeJsonString);
        }

        public async Task AddRecipe()
        {
            recipe.Add(rep);
            var json = JsonConvert.SerializeObject(recipe);

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CurrentAccount.txt");
            var temp = File.ReadAllText(fileName);

            var user = await FirebaseAccountHelper.GetUserByUsername(temp);
            var result = await FirebaseAccountHelper.UpdateUser(user.Username, user.Email, user.Password, user.BackupPass, json);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
