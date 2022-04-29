using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AsaTeb.Persistence.Helpers
{
    public static class HttpClientManager
    {
        private const string BaseUrl = "https://app.ifs.aero/EternalBlue/";

        public static async Task<T?> GetUrlAsync<T>(string url)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var res = await client.GetAsync(url);

            res.EnsureSuccessStatusCode();

            var response = await res.Content.ReadAsStringAsync();
            var entities = JsonConvert.DeserializeObject<T>(response);

            return entities;
        }
        public static async Task PostAsync<T>(string url, T contentValue)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contentValue),
                Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            result.EnsureSuccessStatusCode();
        }

        public static async Task PutAsync<T>(string url, T stringValue)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(stringValue),
                Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, content);
            result.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(string url)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            var result = await client.DeleteAsync(url);
            result.EnsureSuccessStatusCode();
        }
    }
}
