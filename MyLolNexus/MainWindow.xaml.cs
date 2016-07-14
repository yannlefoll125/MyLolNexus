using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            string server = serverComboBox.SelectedValue.ToString();

            TextBox summonerNameTextBox = (TextBox)summoner_name;
            string summonerName = summonerNameTextBox.Text;

            Console.WriteLine("Server: " + server + " summoner name: " + summonerName);

        }
    }
}
