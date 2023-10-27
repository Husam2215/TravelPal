using System.Collections.Generic;
using TravelPal.Enum;

namespace TravelPal.Manage
{
    public class UserManager
    {


        public static List<IUser> users { get; set; } = new()
        {

            new Admin("Admin", "Passwordd",Countries.Sweden),

            new User("User", "Password", Countries.Sweden)
        };

        public static IUser SignedInUser { get; set; }

        public bool addUser(string username, string password, Countries location)
        {
            if (ValidateUsername(username))
            {
                User? user = new(username, password, location);
                users.Add(user);
                return true;
            }
            else return false;
        }

        //public void RemoveUser(string username, string password, Countries location)
        //{

        //}
        //public bool UppdateUsername(string username)
        //{

        //}

        private bool ValidateUsername(string username)
        {
            bool isValidUsername = false;

            if (!string.IsNullOrEmpty(username))
            {
                isValidUsername = true;
            }

            foreach (var user in users)
            {
                if (user.UserName == username)
                {
                    isValidUsername = false;
                }
            }

            return isValidUsername;
        }

        public static bool SignInUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    SignedInUser = user;
                    return true;
                }
            }

            return false;
        }
    }
}
