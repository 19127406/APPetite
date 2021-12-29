using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Firebase.Storage;
using Xamarin.Essentials;
using FFImageLoading;
using System.IO;

namespace APPetite.ViewModels
{
    public class FirebaseStorageHelper
    {
        public static FirebaseStorage firebaseStorage = new FirebaseStorage("projectse-21-22.appspot.com",
            new FirebaseStorageOptions { ThrowOnCancel = true });


        public static async Task<string> Upload_File(string path, FileResult file)
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

        public static async Task<string> Download_Json(string fileName)
        {
            if (!fileName.Contains(".json"))
                fileName += ".json";
            try
            {
                var fileURL = await firebaseStorage
                    .Child("DATABASE")
                    .Child(fileName)
                    .GetDownloadUrlAsync();

                var json = String.Empty;
                using (var webClient = new WebClient())
                {
                    json = webClient.DownloadString(fileURL);
                    //string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp.txt");
                    //using (var fileStream = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    //{
                    //    using (StreamWriter sw = new StreamWriter(fileStream))
                    //    {
                    //        fileStream.SetLength(0);
                    //        sw.Write(json);
                    //    }
                    //}
                }

                return json;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return String.Empty;
            }
        }

        //public async Task<FileResult> Choose_Image_Gallery()
        //{
        //    var photo = await MediaPicker.PickPhotoAsync();
        //    return photo;
        //}
    }
}
