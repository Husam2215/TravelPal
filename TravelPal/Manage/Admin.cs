using TravelPal.Enum;

namespace TravelPal.Manage
{
    public class Admin : IUser
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public Countries Location { get; set; }

        // Add Constructor 

        public Admin(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }
    }
}
