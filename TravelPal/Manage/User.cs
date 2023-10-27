using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Vacation;

namespace TravelPal.Manage
{
    internal class User : IUser
    {
        // Add prop from IUser

        public string? UserName { get; set; }
        public string? Password { get; set; }

        public Countries Location { get; set; }

        // Add new props 
        public List<Travel> Travels { get; set; }

        public User(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;

        }
    }
}
