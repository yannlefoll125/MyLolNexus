using MyLolNexus.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus.RestApi {
    class ApiHelper {

        public static CurrentGame RequestCurrentGame(ApiResourceBuilder.ServerRegion serverRegion, string summonerName) {

            string apiBaseUrl = ApiResourceBuilder.GetApiBaseUrl(serverRegion);


            //Getting summoner ID
            string url = ApiResourceBuilder.GetResourceUrl(serverRegion, ApiResourceBuilder.ApiResource.Summoner);
            url += "by-name/" + summonerName;


            Console.WriteLine("requesting summoner info");

            ApiResponse summonerResponse = RestApiProxy.GetRequest(url, null);

            Console.WriteLine("summoner info fetched");

            if (summonerResponse.StatusCode == System.Net.HttpStatusCode.OK) {
                var s = Summoner.DeserializeSummonerByName(summonerResponse.JsonString);
                
                var summonerId = s.id;

                var currentGameUrlString = ApiResourceBuilder.GetCurrentGameUrl(serverRegion, summonerId);

                var currentGameResponse = RestApiProxy.GetRequest(currentGameUrlString);

                CurrentGame currentGame = CurrentGame.DeserializeCurrentGame(currentGameResponse.JsonString);

                return currentGame;
            }


            return null;
        }

        public static CurrentGame GetDummyCurrentGame() {
            var jsonCurrentGame = Properties.Resources.current_game_santana_claus;
            return CurrentGame.DeserializeCurrentGame(jsonCurrentGame);
        }


    }
}
