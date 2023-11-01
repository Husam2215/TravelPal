using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Manage;
using TravelPal.TravelModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravel.xaml
    /// </summary>
    public partial class AddTravel : Window
    {
        public AddTravel()
        {
            InitializeComponent();

            // Lägg till alla länder
            CbCountry.ItemsSource = Enum.GetValues(typeof(Countries));


            // Om det är en jobb resa eller semster
            CbTypeOfTrip.Items.Add("Work Trip");
            CbTypeOfTrip.Items.Add("Vacation");

            for (int i = 1; i <= 10; i++)
            {
                CbTravelers.Items.Add(i);
            }

        }

        private void CbTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }

        private void CbTrip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbTypeOfTrip.SelectedItem == "Work Trip")
            {
                lblWorkTrip.Visibility = Visibility.Visible;
                txtWorkTrip.Visibility = Visibility.Visible;
                CheckAllinclusive.Visibility = Visibility.Hidden;

            }

            else if (CbTypeOfTrip.SelectedItem == "Vacation")
            {
                CheckAllinclusive.Visibility = Visibility.Visible;
                lblWorkTrip.Visibility = Visibility.Hidden;
                txtWorkTrip.Visibility = Visibility.Hidden;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            // Hämta och Checka alla inputs (så dom inte är tomma)

            bool city = txtCity.Text.Trim().Length > 0;
            bool travelers = CbTravelers.SelectedItem != null;
            bool country = CbCountry.SelectedItem != null;
            bool typeOfTrip = CbTypeOfTrip.SelectedItem != null;


            if (city && travelers && country && typeOfTrip)
            {
                Countries selectedCountry = (Countries)CbCountry.SelectedItem;


                // Skapa resan
                string tripType = (string)CbTypeOfTrip.SelectedItem;

                if (tripType.ToLower() == "work trip")
                {
                    // Skapa en jobbresa

                    WorkTrip newWorkTrip = new(txtWorkTrip.Text, txtCity.Text, (int)CbTravelers.SelectedItem, selectedCountry);

                    // Lägg till resan till vår user

                    ((User)UserManager.SignedInUser).Travels.Add(newWorkTrip);
                }
                else if (tripType.ToLower() == "vacation")
                {
                    // Skapa en semesterresa

                    Vacation newVacation = new(allInclusive: (bool)CheckAllinclusive.IsChecked, destination: txtCity.Text, travellers: (int)CbTravelers.SelectedItem, countries: selectedCountry);

                    // Lägg till resan till vår user

                    ((User)UserManager.SignedInUser).Travels.Add(newVacation);
                }


                TravelsWindow travelsWindow = new();
                travelsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Warning, you have to fill in the missing");
            }



        }
    }
}
