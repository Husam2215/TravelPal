using System.Windows;
using TravelPal.Manage;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();

            lblName.Content = UserManager.SignedInUser.UserName;
        }
    }
}
