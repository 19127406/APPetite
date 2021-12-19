using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APPetite.Models;
using Firebase.Storage;
using Xamarin.Essentials;
using Plugin.Media;
using FFImageLoading;
using System.IO;

namespace APPetite.ViewModels
{
    public class FirebaseStorageHelper
    {
        public static FirebaseStorage firebaseStorage = new FirebaseStorage("projectse-21-22.appspot.com",
            new FirebaseStorageOptions { ThrowOnCancel = true });


        public static async Task<string> Upload_To_FirebaseStorage(string path, FileResult file)
        {
            if (file == null)
            {
                return null;
            }
            try
            {
                var fileURL = await firebaseStorage
                         .Child(path.Replace("\\", "/"))
                         .Child(file.FileName)
                         .PutAsync(await file.OpenReadAsync());
                return fileURL;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }


        public static async void Download_Image_From_FirebaseStorage(string path, string fileName)
        {
            try
            {
                var fileURL = await firebaseStorage
                    .Child(path.Replace("\\", "/"))
                    .Child(fileName)
                    .GetDownloadUrlAsync();

                Stream imageByteArray = await ImageService.Instance.LoadUrl(fileURL)
                    .Retry(3, 300)
                    .AsPNGStreamAsync();

                DirectoryInfo info = new DirectoryInfo("..\\Temp");
                if (!info.Exists)
                {
                    info.Create();
                }

                string tempPath = Path.Combine("..\\Temp", fileName);
                using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
                {
                    imageByteArray.CopyTo(outputFileStream);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }

        public async Task<FileResult> Choose_Image_Gallery()
        {
            var photo = await MediaPicker.PickPhotoAsync();
            return photo;
        }
    }
}
