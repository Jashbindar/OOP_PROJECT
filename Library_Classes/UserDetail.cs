using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class UserDetail : People
    {
        [FirestoreProperty]
        public string ?email { get; set; }
        [FirestoreProperty]
        public string ?password { get; set; }
        [FirestoreProperty]
        public string ?user_ID { get; set; }

        // when the email and password when checked are not valid, an exception is thrown causing the failure to create object
        public UserDetail() { }

        public UserDetail(string a_email, string a_password)
        {
            email = a_email;
            password = a_password;
        }

        public UserDetail (string a_email, string a_password, string a_name)
        {
            name = a_name;
            email = a_email;
            password = a_password;
            user_ID = Guid.NewGuid().ToString();
        }
        public UserDetail (string a_email, string a_password, string a_user_ID, string a_name):base(a_name)
        {
            email = a_email;
            password = a_password;
            user_ID = a_user_ID;
        }

        public string ValidateEmail (string a_email)
        {
            if (string.IsNullOrWhiteSpace(a_email) == false && a_email.Contains("@") == true && a_email.EndsWith(".com") == true)
            {
                return a_email;
            }
            else
            {
                throw new ArgumentException("Invalid gmail");
            }
        }

        public string ValidatePassword (string a_password)
        {
            if (string.IsNullOrWhiteSpace(a_password) == false)
            {
                return a_password;
            }
            else
            {
                throw new ArgumentException("Password can't be empty!");
            }
        }

        public void DisplayUserData()
        {
            Console.WriteLine("\nUser ID: {0}", user_ID);
            Console.WriteLine("User Email: {0}", email);
            Console.WriteLine("User Password: {0}", password);
            Console.WriteLine("User Name: {0}", name);
        }

        public string getEmail()
        {
            return email;
        }
        public string getPassword()
        {
            return password;
        }
        public string getUserID()
        {
            return user_ID;
        }

    }
}
