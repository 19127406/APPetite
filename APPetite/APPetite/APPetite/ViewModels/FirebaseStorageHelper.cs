using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APPetite.Models;
using Firebase.Storage;
using Xamarin.Essentials;

namespace APPetite.ViewModels
{
    public class FirebaseStorageHelper
    {
        public static FirebaseStorage firebaseStorage = new FirebaseStorage("projectse-21-22.appspot.com",
            new FirebaseStorageOptions { ThrowOnCancel = true });


        public static async void Upload(string path, FileResult file)
        {
            try
            {
                await firebaseStorage
                         .Child(path.Replace("\\", "/"))
                         .PutAsync(await file.OpenReadAsync());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }


        public static async void Download(string path)
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }
    }
}
