using TravelPal.Enum;

namespace TravelPal.Manage
{
    // Add properites

    public interface IUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Countries Location { get; set; }

        // Add constructor

        public void IUser(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }
    }
}
