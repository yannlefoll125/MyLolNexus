using MyLolNexus.Data;
using MyLolNexus.Model;
using MyLolNexus.RestApi;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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


            //CurrentGameModel cgm = ModelHelper.GetCurrentGameModel(serverRegion, summonerName);
            CurrentGameModel cgm = ModelHelper.GetDummyCurrentGameModel();

            Console.WriteLine(cgm.ToString());

            foreach(ParticipantModel pm in cgm.Team1) {
                ParticipantView pv = new ParticipantView();
                pv.summonerName.Content = pm.SummonerName;

                var imageName = pm.ChampionName + "_Square_0.png";

                pv.championImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Champions/" + imageName));


                this.team1StackPanel.Children.Add(pv);
            }
            

        }
    }
}
