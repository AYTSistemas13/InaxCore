using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaxCore
{
    public class OdataConection
    {

        public static async Task<Dictionary<string, dynamic>> Query(String Query, int TimeOut = 5000000)
        {
            //Pruebas
            //string URL = "https://tes-ayt.sandbox.operations.dynamics.com/Data/";
            // Variable produccion 
            string URL = "https://ayt.operations.dynamics.com/Data/";
            String token = await getToken();
            var client = new RestClient(URL + Query);
            client.Timeout = TimeOut;
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            IRestResponse response = client.Execute(request);
            var jsonAttributes = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response.Content);
            return jsonAttributes;
        }

        public static async Task<string> QueryJson(String Query, int TimeOut = 5000000)
        {
            //Pruebas
            //string URL = "https://tes-ayt.sandbox.operations.dynamics.com/Data/";
            // Variable produccion 
            string URL = "https://ayt.operations.dynamics.com/Data/";
            String token = await getToken();
            var client = new RestClient(URL + Query);
            client.Timeout = TimeOut;
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static async Task<string> PostQueryJson(string Query,string postString, int TimeOut = 5000000)
        {
            //Pruebas
            //string URL = "https://tes-ayt.sandbox.operations.dynamics.com";
            // Variable produccion 
            string URL = "https://ayt.operations.dynamics.com";
            String token = await getToken();
            var client = new RestClient(URL + Query);
            client.Timeout = TimeOut;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + token);
            request.AddCookie("ApplicationGatewayAffinity", "e7fb295f94cb4b5e0cd1e2a4712e4a803fc926342cc4ecca988f29125dbd4b04");
            request.AddParameter("application/json", postString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
        public static async Task<string> PatchQueryJson(string Query,string patchString, int TimeOut = 5000000)
        {
            //Pruebas
            //string URL = "https://tes-ayt.sandbox.operations.dynamics.com";
            // Variable produccion 
            string URL = "https://ayt.operations.dynamics.com";
            String token = await getToken();
            var client = new RestClient(URL + Query);
            client.Timeout = TimeOut;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + token);
            request.AddCookie("ApplicationGatewayAffinity", "e7fb295f94cb4b5e0cd1e2a4712e4a803fc926342cc4ecca988f29125dbd4b04");
            request.AddParameter("application/json", patchString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        private static async Task<string> getToken()
        {
            //Produccion
            var client = new RestClient("https://solutiontinax-solutiontokeninaxpr.azurewebsites.net/SolutionToken/api/SolutionToken");
            //Pruebas
            //var client = new RestClient("https://solutiontinaxdev.azurewebsites.net/SolutionToken/api/SolutionToken");
            var request = new RestRequest(Method.GET);
            request.AddCookie("ARRAffinity", "80acad023b61db9f585bb1886d9413f971193c63e63186520a0e7cc52daae5df");
            IRestResponse response = await client.ExecuteAsync(request);
            //This line deletes the [] on the response for serialization
            String jsonContent = response.Content.Replace("[", "").Replace("]", "");
            var tokenSerialized = JsonConvert.DeserializeObject<ResponseToken>(jsonContent);
            return tokenSerialized.Token;
        }
    }
    public class ResponseToken
    {
        public string Token { get; set; }
    }
}





