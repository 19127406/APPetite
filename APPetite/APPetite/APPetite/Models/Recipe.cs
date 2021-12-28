using System;
using System.Collections.Generic;
using System.Text;

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
    }

    public class Data
    {
        public string type { get; set; }
        public List<Recipe> list { get; set; }
    }

}
