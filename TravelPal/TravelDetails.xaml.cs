using System.Windows;
using System.Windows.Controls;
using TravelPal.TravelModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetails.xaml
    /// </summary>
    public partial class TravelDetails : Window
    {
        public TravelDetails(Travel selectedTravel)
        {
            InitializeComponent();
            ListViewItem item = new();
            item.Tag = selectedTravel;
            item.Content = selectedTravel.GetInfo();
            lstView.Items.Add(item);
        }

        private void lstView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();

        }
    }
}
