using APPetite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace APPetite.ViewModels
{
    [QueryProperty(nameof(json), nameof(json))]
    public class CategoryView
    {
        public string json { get; set; }
    }
}
