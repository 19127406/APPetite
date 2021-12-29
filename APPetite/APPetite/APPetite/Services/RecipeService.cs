using APPetite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace APPetite.Services
{
    public class RecipeService
    {
        public async Task<List<Data>> GetRecipeAllList()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("https://firebasestorage.googleapis.com/v0/b/projectse-21-22.appspot.com/o/DATABASE%2Fdata_food.json?alt=media&token=600d7846-6f77-4f27-9daf-f244de5763ce");
                var recipe = JsonConvert.DeserializeObject<List<Data>>(json);
                return recipe;
            }
            catch (Exception e)
            {
                
            }
            return null;
        }
    }
}
