using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Airports.BLL
{
    public class ExternalResourcesLoader
    {
        static HttpClient client = new HttpClient();

        public static async Task<T> GetAsync<T>(string requestUrl) where T : class
        {
            return await DoCall<T>(requestUrl);
        }

        public static async Task<List<T>> GetListAsync<T>(string requestUrl) where T : class
        {
            return await DoCall<List<T>>(requestUrl);
        }

        private static async Task<T> DoCall<T>(string requestUrl) where T : class
        {
            var response = await client.GetAsync(requestUrl);
            T result = null;

            if (response.IsSuccessStatusCode)
                result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            return result;
        }
    }
}
