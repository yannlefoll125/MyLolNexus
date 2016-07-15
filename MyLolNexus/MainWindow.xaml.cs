using MyLolNexus.Data;
using Newtonsoft.Json;
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
            string server = serverComboBox.Text;

            ApiResourceBuilder.ServerRegion serverRegion = ApiResourceBuilder.GetServerRegionByName(server);


            TextBox summonerNameTextBox = (TextBox)summoner_name;
            string summonerName = summonerNameTextBox.Text;
            


            RestApiProxy restApiProxy = new RestApiProxy();

            string apiBaseUrl = ApiResourceBuilder.GetApiBaseUrl(serverRegion);

            string url = ApiResourceBuilder.GetResourceUrl(serverRegion, ApiResourceBuilder.ApiResource.Summoner);
            url += "by-name/" + summonerName;

            string response = restApiProxy.GetRequest(url, null);

            var s = Summoner.DeserializeSummonerByName(response);

            Console.WriteLine("result: " + s.ToString());

            var summonerId = s.id;
            Console.WriteLine(s.ToString());

        }
    }
}
