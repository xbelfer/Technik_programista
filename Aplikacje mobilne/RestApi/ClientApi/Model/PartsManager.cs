using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientApi.Model
{
    public static class PartsManager
    {
        // TODO: Add fields for BaseAddress, Url, and authorizationKey
        static readonly string BaseAddress = "https://mslearnpartsserver1048716328.azurewebsites.net";
        static readonly string Url = $"{BaseAddress}/api/";

        static HttpClient client;
        private static string authorizationKey;

        private static async Task<HttpClient> GetClient()
        {
            if (client != null)
                return client;

            client = new HttpClient();

            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync($"{Url}login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public static async Task<IEnumerable<Part>> GetAll()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<Part>();

            HttpClient client = await GetClient();
            string result = await client.GetStringAsync($"{Url}parts");

            return JsonConvert.DeserializeObject<List<Part>>(result);
        }
    }
}
