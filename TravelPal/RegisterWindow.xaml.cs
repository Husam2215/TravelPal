using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Manage;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            CbCountries.ItemsSource = Enum.GetValues(typeof(Countries));
            //foreach (Countries countries in Enum.GetValues(typeof(Countries)))
            //{
            //    ListViewItem item = new();
            //    item.Content = countries.ToString();
            //    item.Tag = countries;
            //    CbCountries.Items.Add(item);
            //}

        }

        private void btnRegisterUser_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRegisterUserName.Text) && !string.IsNullOrEmpty(txtRegisterPasword.Text) && CbCountries.SelectedIndex > -1)
            {
                // Läs användarnamnet
                string username = txtRegisterUserName.Text;
                // Läs lösenordet
                string password = txtRegisterPasword.Text;

                Countries selectedCountry = (Countries)CbCountries.SelectedItem;
                // Kör AddUser-metoden med användarnamnet och lösenordet
                bool addUserResult = UserManager.AddUser(username, password, selectedCountry);

                if (addUserResult)
                {
                    MessageBox.Show("User registered successfully");
                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to register user. Username might aready be taken.");
                }
            }
        }

        private void CbCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
