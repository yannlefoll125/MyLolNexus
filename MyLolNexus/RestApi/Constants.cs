using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus.RestApi {
    class Constants {

        public static readonly Dictionary<int, string> summonerSpell = new Dictionary<int, string>() {
            { 1, "cleanse" },
            { 12, "teleport" },
            { 14, "ignite" },
            { 6, "ghost" },
            { 7, "heal" },
            { 11, "smite" },
            { 3, "exhaust" },
            { 21, "barrier" },
            { 4, "flash" }
        };



        public class Team {
            public const long Team1 = 100;
            public const long Team2 = 200;
        }
    }
}
