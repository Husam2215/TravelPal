using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Manage;
using TravelPal.TravelModels;

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

            if (UserManager.SignedInUser.GetType() == typeof(User))
            {
                // Hämta inloggad användare
                User user = (User)UserManager.SignedInUser;
                // Hämta användarens resor
                List<Travel> userTravels = new();
                userTravels = user.Travels;

                // Loopa över alla resor hos användaren
                foreach (var travel in userTravels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = travel;
                    item.Content = travel.Countries;

                    lstView.Items.Add(item);
                }
            }
            else if (UserManager.SignedInUser is Admin)
            {
                List<Travel> allTravels = UserManager.GetAllUserTravels();

                foreach (var travel in allTravels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = travel;
                    item.Content = travel.Countries;

                    lstView.Items.Add(item);
                }
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start buy pressing Add Travel and then filling in all info about your trip then press Add ");
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            MessageBox.Show("Thanks for using this webbsite!");
            Close();

        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravel addTravel = new();
            addTravel.Show();
            Close();
        }

        private void cbFrom_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void CbTo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

            ListViewItem selectedItem = (ListViewItem)lstView.SelectedItem;
            if (selectedItem != null)
            {
                Travel selectedTravel = (Travel)selectedItem.Tag;
                TravelDetails travelDetails = new(selectedTravel);
                travelDetails.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Warning, you have to choose wich trip you want to inspekt");
            }



        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstView.SelectedItem;
            if (selectedItem != null)
            {
                Travel travelToRemove = (Travel)selectedItem.Tag;
                if (UserManager.SignedInUser is User)
                {
                    ((User)UserManager.SignedInUser).Travels.Remove(travelToRemove);
                }
                else if (UserManager.SignedInUser is Admin)
                {
                    UserManager.AdminRemove(travelToRemove);
                }
                lstView.Items.Remove(selectedItem);

            }
            else
            {
                MessageBox.Show("Select wich travel you want to remove");
            }
        }
    }
}
