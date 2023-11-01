using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.TravelModels;

namespace TravelPal.Manage
{
    public class UserManager
    {


        public static List<IUser> Users { get; set; } = new()
        {
            new Admin("admin", "password",Countries.Sweden),
            new User("user", "password", Countries.Sweden)
            {
                Travels = new List<Travel>()
                {
                    new Vacation("Rome", 5, Countries.Italy, true)
                    {

                    },
                    new WorkTrip("Speak to John about Azure SQL database", "Madrid", 3, Countries.Spain)
                    {

                    }
                }
            }
        };

        public static IUser SignedInUser { get; set; }

        public static bool AddUser(string username, string password, Countries destination)
        {
            if (ValidateUsername(username))
            {
                User? user = new(username, password, destination);
                Users.Add(user);
                return true;
            }
            else return false;
        }

        // Hämta alla resor hos alla users (används av admin)
        public static List<Travel> GetAllUserTravels()
        {
            List<Travel> allUserTravels = new();

            foreach (var user in Users)
            {
                if (user is User)
                {
                    allUserTravels.AddRange(((User)user).Travels);
                }
            }

            return allUserTravels;
        }


        private static bool ValidateUsername(string username)
        {
            bool isValidUsername = false;

            if (!string.IsNullOrEmpty(username))
            {
                isValidUsername = true;
            }

            foreach (var user in Users)
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
            foreach (var user in Users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    SignedInUser = user;
                    return true;
                }
            }

            return false;
        }


        public static void AdminRemove(Travel travelToRemove)
        {
            foreach (var user in Users)
            {
                if (user is User)
                {
                    foreach (var travel in ((User)user).Travels)
                    {
                        if (travel == travelToRemove)
                        {
                            ((User)user).Travels.Remove(travelToRemove);

                            return;
                        }
                    }
                }
            }
        }


    }
}
