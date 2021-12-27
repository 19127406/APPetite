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
        public string ingredient
        {
            get;
            set;
        }
        public string step
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
        public int difficulty
        {
            get;
            set;
        }
    }

    public class RootObject
    {
        public string type { get; set; }
        public Recipe[] recipe { get; set; }
    }
}
