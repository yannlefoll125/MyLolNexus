using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyLolNexus {

    class ApiResourceBuilder {
        public enum ServerRegion {
            EUW,
            NA
        };

        private static Dictionary<ServerRegion, string> regionString = new Dictionary<ServerRegion, string>() {
            { ServerRegion.EUW,  "euw" },
            { ServerRegion.NA,  "na"}
        };

        private static Dictionary<string, ServerRegion> stringRegionMap = new Dictionary<string, ServerRegion>() {
            { "euw", ServerRegion.EUW },
            { "na", ServerRegion.NA}
        };

        private static Dictionary<ServerRegion, string> platformIdString = new Dictionary<ServerRegion, string>() {
            { ServerRegion.EUW,  "EUW1" },
            { ServerRegion.NA,  "NA1"}
        };

        public enum ApiResource { Summoner, CurrentGame };


        private static Dictionary<ApiResource, string> apiResource = new Dictionary<ApiResource, string>() {
            { ApiResource.Summoner, Properties.Resources.summoner },
            { ApiResource.CurrentGame, Properties.Resources.current_game }
        };


        public static string GetApiBaseUrl(ServerRegion region) {
            string apiBaseUrl = string.Format(Properties.Resources.api_url, regionString[region]);
            return apiBaseUrl;
        }



        public static string GetResourceUrl(ServerRegion region, ApiResource resource) {
            string apiBaseUrl = GetApiBaseUrl(region);
            string resourceUrl = string.Format(apiResource[resource], regionString[region]);
            
            return apiBaseUrl + resourceUrl;
        }


        public static string GetCurrentGameUrl(ServerRegion region, int summonerId) {
            var apiBaseUrl = GetApiBaseUrl(region);

            var platformId = platformIdString[region];
            var resourceUri = string.Format(apiResource[ApiResource.CurrentGame], platformId, summonerId);




            return apiBaseUrl + resourceUri;
        }
        
        public static ServerRegion GetServerRegionByName(string name) {

            name = name.ToLowerInvariant();

            return stringRegionMap[name];
        }
        
            


    }

    class RestApiProxy {

        private const string API_KEY = "93988639-94c2-475d-a80a-c46dc4cb4522";
        private const string API_KEY_PARAM = "?api_key=" + API_KEY;

        private string BuildUrlParameters(Dictionary<string, string> parameters) {
            string urlParameters = API_KEY_PARAM;

            if (parameters == null) {
                return urlParameters;
            }

            foreach(KeyValuePair<string, string> entry in parameters) {
                urlParameters += "&" + entry.Key + "=" + entry.Value;
            }

            return urlParameters;
        }

        public string GetRequest(string base_url) {
            return GetRequest(base_url, new Dictionary<string, string>());
        } 

        public string GetRequest(string base_url, Dictionary<string, string> parameters) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            string urlParameters = BuildUrlParameters(parameters);

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            if(response.IsSuccessStatusCode) {
                return response.Content.ReadAsStringAsync().Result;
            } else {
                return "Error";
            }

            
        }
    }
}
