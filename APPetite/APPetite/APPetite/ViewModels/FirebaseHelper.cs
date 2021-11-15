using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using APPetite.Models;

namespace APPetite.ViewModels
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://projectse-21-22-default-rtdb.asia-southeast1.firebasedatabase.app/");

        //Read All    
        public static async Task<List<Account>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Account")
                .OnceAsync<Account>()).Select(item =>
                new Account
                {
                    Username = item.Object.Username,
                    Password = item.Object.Password
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<Account> GetUser(string username)
        {
            try
            {
                var allAccount = await GetAllUser();
                await firebase
                .Child("Account")
                .OnceAsync<Account>();
                return allAccount.Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a user    
        public static async Task<bool> AddUser(string username, string email, string password)
        {
            try
            {


                await firebase
                .Child("Account")
                .PostAsync(new Account() { Username = username, Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update        
        public static async Task<bool> UpdateUser(string username, string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Account")
                .OnceAsync<Account>()).Where(a => a.Object.Username == username).FirstOrDefault();
                await firebase
                .Child("Account")
                .Child(toUpdateUser.Key)
                .PutAsync(new Account() { Username = username, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User    
        //public static async Task<bool> DeleteUser(string username)
        //{
        //    try
        //    {


        //        var toDeletePerson = (await firebase
        //        .Child("Account")
        //        .OnceAsync<Account>()).Where(a => a.Object.Username == username).FirstOrDefault();
        //        await firebase.Child("Account").Child(toDeletePerson.Key).DeleteAsync();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"Error:{e}");
        //        return false;
        //    }
        //}

    }
}
