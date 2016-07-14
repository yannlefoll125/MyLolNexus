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

        public enum ApiResource { Summoner, CurrentGame };


        private static Dictionary<ApiResource, string> apiResource = new Dictionary<ApiResource, string>() {
            { ApiResource.Summoner, Properties.Resources.summoner }
        };


        public static string GetApiBaseUrl(ServerRegion region) {
            string apiBaseUrl = string.Format(Properties.Resources.api_url, regionString[region]);
            Console.WriteLine("apiBaseUrl: " + apiBaseUrl);
            return apiBaseUrl;
        }



        public static string GetResourceUrl(ServerRegion region, ApiResource resource) {
            string apiBaseUrl = GetApiBaseUrl(region);
            string resourceUrl = string.Format(apiResource[resource], regionString[region]);

            Console.WriteLine("resourceUrl: " + apiBaseUrl + resourceUrl);
            return apiBaseUrl + resourceUrl;
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

            Console.WriteLine("base_url: " + base_url);
            Console.WriteLine(client.BaseAddress.ToString());

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            Console.WriteLine("Request: " + response.RequestMessage.ToString());

            if(response.IsSuccessStatusCode) {
                return response.Content.ReadAsStringAsync().Result;
            } else {
                Console.WriteLine("Error: " + response.StatusCode.ToString());
                return "Error";
            }

            
        }
    }
}
