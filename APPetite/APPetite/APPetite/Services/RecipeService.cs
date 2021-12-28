using APPetite.Models;
using APPetite.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace APPetite.Services
{
    public class RecipeService
    {
        public List<Data> GetRecipeAllList()
        {
            //var json = await FirebaseStorageHelper.Download_Json("data_food.json");
            //var recipe = JsonConvert.DeserializeObject<List<Data>>(json);
            //return recipe;
            return new List<Data>()
                {
                    new Data() { type="Image1", list = new List<Recipe>()
                    {
                         new Recipe()
                         {
                             name = "concac", imageSource = "https://firebasestorage.googleapis.com/v0/b/projectse-21-22.appspot.com/o/Image_food%2FBanh_ngot%2FBanh_la_dua%2F1.png?alt=media&token=5e350e02-7167-4c6d-982f-3e162c4a769e"
                         }
                    }
                    }
                };
        }
    }
}
