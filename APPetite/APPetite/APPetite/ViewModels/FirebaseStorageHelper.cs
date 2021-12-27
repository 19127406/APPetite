using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APPetite.Models;
using Firebase.Storage;
using Xamarin.Essentials;
using Plugin.Media;
using FFImageLoading;
using System.IO;
using Newtonsoft.Json;

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


        public static async Task<bool> Download_Image(string path, string fileName)
        {
            try
            {
                var fileURL = await firebaseStorage
                    .Child("Image_food")
                    .Child(path.Replace("\\", "/"))
                    .Child(fileName)
                    .GetDownloadUrlAsync();

                Stream imageByteArray = await ImageService.Instance.LoadUrl(fileURL)
                    .Retry(3, 300)
                    .DownSample(512, 512)
                    .AsPNGStreamAsync();

                //var haha = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string tempPath = Path.Combine(FileSystem.CacheDirectory, path.Replace("\\", "/").Split('/')[1] + ".png");
                // tempPath = "/data/user/0/com.companyname.appetite/cache/1.png"
                //string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);
                using (var fileStream = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    imageByteArray.Position = 0;
                    imageByteArray.CopyTo(fileStream);
                    fileStream.Dispose();
                    fileStream.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> Download_Json(string fileName)
        {
            try
            {
                var fileURL = await firebaseStorage
                    .Child("DATABASE")
                    .Child(fileName + ".json")
                    .GetDownloadUrlAsync();

                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(fileURL);
                    string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp.txt");
                    using (var fileStream = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fileStream))
                        {
                            fileStream.SetLength(0);
                            sw.Write(json);
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //public async Task<FileResult> Choose_Image_Gallery()
        //{
        //    var photo = await MediaPicker.PickPhotoAsync();
        //    return photo;
        //}
    }
}
