using APPetite.Models;
using APPetite.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APPetite.ViewModels
{
    public class RecipeView
    {
        public List<Data> data { get; set; }

        public RecipeView()
        {
            data = new RecipeService().GetRecipeAllList();
        }

        public List<string> getImageSource()
        {
            List<string> imageUrl = new List<string>();
            foreach (var list in data)
            {
                foreach (var recipe in list.list)
                {
                    imageUrl.Add(recipe.imageSource);
                }
            }
            return imageUrl;
        }
    }
}
