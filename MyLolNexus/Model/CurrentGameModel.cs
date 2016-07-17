using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus.Model {

    class CurrentGameModel {

        public List<ParticipantModel> Team1 { get; set; }
        public List<ParticipantModel> Team2 { get; set; }

        public CurrentGameModel() {
            Team1 = new List<ParticipantModel>();
            Team2 = new List<ParticipantModel>();

        }

        public override string ToString() {
            var str = "Team1 \n";
            foreach(ParticipantModel pm in Team1) {
                str += pm.ToString() + "\n";
            }

            str += "Team2\n";
            foreach (ParticipantModel pm in Team2) {
                str += pm.ToString() + "\n";
            }

            return str;
        }

    }

    class ParticipantModel {
        public string SummonerName { get; set; }
        public string ChampionName { get; set; }
        public List<string> SummonerSpells { get; set; }

        public ParticipantModel() {
            SummonerName = "";
            ChampionName = "";

            SummonerSpells = new List<string>(2);
            SummonerSpells.Add("SummonerSpell1");
            SummonerSpells.Add("SummonerSpell2");
        }

        public override string ToString() {
            var str = "Summoner name: " + SummonerName;
            str += " | Champions name: " + ChampionName;
            str += " | Summoner spells: " + SummonerSpells.ElementAt<string>(0) + ", " + SummonerSpells.ElementAt<string>(1);
            return str;

        }

    }
}
