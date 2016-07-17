using MyLolNexus.Data;
using MyLolNexus.Model;
using MyLolNexus.RestApi;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyLolNexus {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ok_button_Click(object sender, RoutedEventArgs e) {
            ComboBox serverComboBox = (ComboBox)server_combobox;
            string server = serverComboBox.Text;

            ApiResourceBuilder.ServerRegion serverRegion = ApiResourceBuilder.GetServerRegionByName(server);


            TextBox summonerNameTextBox = (TextBox)summoner_name;
            string summonerName = summonerNameTextBox.Text;

            
            CurrentGameModel cgm = ModelHelper.GetCurrentGameModel(serverRegion, summonerName);

            Console.WriteLine(cgm.ToString());

            

        }
    }
}
