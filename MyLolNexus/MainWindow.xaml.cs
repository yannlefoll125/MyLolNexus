using MyLolNexus.Data;
using MyLolNexus.Model;
using MyLolNexus.RestApi;
using System;
using System.Collections.Generic;
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


            CurrentGameModel cgm = ModelHelper.GetCurrentGameModel(serverRegion, summonerName);
            //CurrentGameModel cgm = ModelHelper.GetDummyCurrentGameModel();

            Console.WriteLine(cgm.ToString());


            fillTeamPanel(cgm.Team1, this.team1StackPanel);
            fillTeamPanel(cgm.Team2, this.team2StackPanel);

        }

        private void fillTeamPanel(List<ParticipantModel> participantModelList, StackPanel teamStackPanel) {
            foreach (ParticipantModel pm in participantModelList) {
                ParticipantView pv = new ParticipantView();
                pv.summonerName.Content = pm.SummonerName;

                var imageName = pm.ChampionName + "_Square_0.png";

                pv.championImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Champions/" + imageName));


                var summonerSpell1Image = pm.SummonerSpells[0] + ".png";
                var summonerSpell2Image = pm.SummonerSpells[1] + ".png";
                pv.summonerSpell1Image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/SummonerSpells/" + summonerSpell1Image));
                pv.summonerSpell2Image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/SummonerSpells/" + summonerSpell2Image));

                teamStackPanel.Children.Add(pv);
            }
        }
    }
}
