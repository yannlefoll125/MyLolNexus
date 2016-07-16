using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus.Data {

    public class CurrentGame {
        public int gameLength { get; set; }
        public string gameMode { get; set; }
        public int mapId { get; set; }
        public Bannedchampion[] bannedChampions { get; set; }
        public string gameType { get; set; }
        public long gameId { get; set; }
        public Observers observers { get; set; }
        public int gameQueueConfigId { get; set; }
        public long gameStartTime { get; set; }
        public Participant[] participants { get; set; }
        public string platformId { get; set; }

        public static CurrentGame DeserializeCurrentGame(string jsonString) {

            CurrentGame currentGame = JsonConvert.DeserializeObject<CurrentGame>(jsonString);

            return currentGame;
        }
    }

    public class Observers {
        public string encryptionKey { get; set; }
    }

    public class Bannedchampion {
        public int pickTurn { get; set; }
        public int championId { get; set; }
        public int teamId { get; set; }
    }

    public class Participant {
        public Mastery[] masteries { get; set; }
        public bool bot { get; set; }
        public Rune[] runes { get; set; }
        public int spell2Id { get; set; }
        public int profileIconId { get; set; }
        public string summonerName { get; set; }
        public int championId { get; set; }
        public int teamId { get; set; }
        public int summonerId { get; set; }
        public int spell1Id { get; set; }
    }

    public class Mastery {
        public int rank { get; set; }
        public int masteryId { get; set; }
    }

    public class Rune {
        public int count { get; set; }
        public int runeId { get; set; }
    }

}
