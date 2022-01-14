using APPetite.Models;
using APPetite.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APPetite.ViewModels
{
    public class RecipeView : INotifyPropertyChanged
    {
        protected RecipeService service = new RecipeService();

        public ObservableCollection<Data> data { get; set; }

        public ObservableCollection<Recipe> firstCollection { get; set; }
        public ObservableCollection<Recipe> secondCollection { get; set; }
        public ObservableCollection<Recipe> thirdCollection { get; set; }

        public ICommand GetRecipeCommand { get; set; }

        public bool IsRunning { get; set; }

        public RecipeView()
        {
            firstCollection = new ObservableCollection<Recipe>();
            secondCollection = new ObservableCollection<Recipe>();
            thirdCollection = new ObservableCollection<Recipe>();
            GetRecipeCommand = new Command(async () => await GetRecipe());
            GetRecipeCommand.Execute(null);
        }

        private async Task GetRecipe()
        {
            IsRunning = true;

            var result = await service.GetRecipeAllList();
            if (result != null)
                data = new ObservableCollection<Data>(result);

            IsRunning = false;

            Random rnd = new Random();
            for (int iter = 0; iter < 3; iter++)
            {
                int i = 0, n = 0;
                if (iter == 0)
                    n = 5;
                else if (iter == 1)
                    n = 7;
                else n = 15;

                foreach (var list in data)
                {

                    if (i == n)
                        break;
                    while (rnd.Next(0, 2) == 1)
                    {
                        while (true)
                        {
                            var randomRep = list.list[rnd.Next(0, list.list.Count)];
                            var flagDuplicate = false;
                            if (iter == 0)
                            {
                                foreach (var meal in firstCollection)
                                {
                                    if (meal.Equals(randomRep))
                                    {
                                        flagDuplicate = true;
                                        break;
                                    }
                                }
                                if (flagDuplicate == false)
                                {
                                    firstCollection.Add(randomRep);
                                    i += 1;
                                    break;
                                }
                            }
                            else if (iter == 1)
                            {
                                foreach (var meal in secondCollection)
                                {
                                    if (meal.Equals(randomRep))
                                    {
                                        flagDuplicate = true;
                                        break;
                                    }
                                }
                                if (flagDuplicate == false)
                                {
                                    secondCollection.Add(randomRep);
                                    i += 1;
                                    break;
                                }
                            }
                            else
                            {
                                foreach (var meal in thirdCollection)
                                {
                                    if (meal.Equals(randomRep))
                                    {
                                        flagDuplicate = true;
                                        break;
                                    }
                                }
                                if (flagDuplicate == false)
                                {
                                    thirdCollection.Add(randomRep);
                                    i += 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void refreshRandomData(ObservableCollection<Recipe> firstCollection, ObservableCollection<Recipe> secondCollection, ObservableCollection<Recipe> thirdCollection, ObservableCollection<Data> data)
        {
            firstCollection.Clear();
            secondCollection.Clear();
            thirdCollection.Clear();
            Random rnd = new Random();
            for (int iter = 0; iter < 3; iter++)
            {
                int i = 0, n = 0;
                if (iter == 0)
                    n = 5;
                else if (iter == 1)
                    n = 7;
                else n = 15;

                foreach (var list in data)
                {

                    if (i >= 5)
                        break;
                    while (rnd.Next(0, 2) == 1)
                    {
                        while (true)
                        {
                            var randomRep = list.list[rnd.Next(0, list.list.Count)];
                            var flagDuplicate = false;
                            foreach (var meal in firstCollection)
                            {
                                if (meal.Equals(randomRep))
                                {
                                    flagDuplicate = true;
                                    break;
                                }
                            }
                            if (flagDuplicate == false)
                            {
                                firstCollection.Add(randomRep);
                                i += 1;
                                break;
                            }
                        }
                    }
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}