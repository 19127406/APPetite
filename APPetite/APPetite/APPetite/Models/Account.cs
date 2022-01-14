using Newtonsoft.Json;
using System.Collections.Generic;

namespace APPetite.Models
{
    public class Account
    {
        public string Username
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string BackupPass
        {
            get;
            set;
        }
        public string RecipeJson
        {
            get;
            set;
        }
        public List<Data> jsonToListRecipe()
        {
            return JsonConvert.DeserializeObject<List<Data>>(RecipeJson);
        }
        public void listToRecipeJson(List<Data> value)
        {
            RecipeJson = JsonConvert.SerializeObject(value);
        }
    }
}
