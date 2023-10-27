using System.Windows;
using TravelPal.Manage;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUserName.Text;
            string password = txtPassword.Text;


            bool isSignedIn = UserManager.SignInUser(username, password);


            if (isSignedIn)
            {
                TravelsWindow travelsWindow = new();
                travelsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("The Username or Password is wrong");
            }
        }
    }
}
