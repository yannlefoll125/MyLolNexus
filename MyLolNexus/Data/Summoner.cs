using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus.Data {

    public class Summoner {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public int summonerLevel { get; set; }
        public long revisionDate { get; set; }

        public override string ToString() {
            var output = "";

            output += "id: " + this.id + " name: " + this.name + " profileIconId: " + profileIconId + " summonerLevel: " + summonerLevel +
                " revisionDate: " + revisionDate;

            return output;
        }

        public static Summoner DeserializeSummonerByName(string jsonString) {

            JObject jObject = JObject.Parse(jsonString);

            IList<JToken> children = jObject.Children().ToList();

            JToken summonerToken = children[0].First;

            return JsonConvert.DeserializeObject<Summoner>(summonerToken.ToString());


        }
    }



}
