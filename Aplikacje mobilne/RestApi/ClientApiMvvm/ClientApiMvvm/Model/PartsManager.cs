using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientApiMvvm.Model
{
    public static class PartsManager
    {
        // TODO: Add fields for BaseAddress, Url, and authorizationKey
        static readonly string BaseAddress = "https://mslearnpartsserver10777854.azurewebsites.net";
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

        public static async Task<Part> GetPart(string partId)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new Part();

            HttpClient client = await GetClient();
            string result = await client.GetStringAsync($"{Url}parts/{partId}");

            return JsonConvert.DeserializeObject<Part>(result);
        }


        public static async Task<Part> Add(string partName, string supplier, string partType)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new Part();

            try
            {
                var part = new Part()
                {
                    PartName = partName,
                    Suppliers = new List<string>(new[] { supplier }),
                    PartID = string.Empty,
                    PartType = partType,
                    PartAvailableDate = DateTime.Now.Date
                };

                HttpClient client = await GetClient();

                var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");
                msg.Content = JsonContent.Create<Part>(part);

                var response = await client.SendAsync(msg);
                response.EnsureSuccessStatusCode();

                var returnedJson = await response.Content.ReadAsStringAsync();

                var insertedPart = JsonConvert.DeserializeObject<Part>(returnedJson);

                return insertedPart;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;// new Part();
            }
        }

        public static async Task<bool> Update(Part part)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            try
            {
                HttpRequestMessage msg = new(HttpMethod.Put, $"{Url}parts/{part.PartID}");

                msg.Content = JsonContent.Create<Part>(part);

                HttpClient client = await GetClient();

                var response = await client.SendAsync(msg);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> Delete(string partID)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            try
            {
                HttpRequestMessage msg = new(HttpMethod.Delete, $"{Url}parts/{partID}");

                HttpClient client = await GetClient();

                var response = await client.SendAsync(msg);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
