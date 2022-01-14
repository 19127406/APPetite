using Newtonsoft.Json;
using System.Collections.Generic;

namespace APPetite.Models
{
    public class Recipe
    {
        public string name
        {
            get;
            set;
        }
        public List<string> ingredient
        {
            get;
            set;
        }
        public List<string> step
        {
            get;
            set;
        }
        public string imageSource
        {
            get;
            set;
        }
        public string numberPerson
        {
            get;
            set;
        }
        public string cookingTime
        {
            get;
            set;
        }
        public string difficulty
        {
            get;
            set;
        }
        public int likes
        {
            get;
            set;
        }
        //public string publisher
        //{
        //    get;
        //    set;
        //}
        //public string category
        //{
        //    get;
        //    set;
        //}
        public bool Equals(Recipe other)
        {
            if (this.name != other.name) return false;
            return true;
        }
    }

    public class Data
    {
        public string type { get; set; }
        public List<Recipe> list { get; set; }

        public string dataToJson(List<Data> value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
