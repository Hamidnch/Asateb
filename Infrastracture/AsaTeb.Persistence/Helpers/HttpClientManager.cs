using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AsaTeb.Domain.Technologies;
using Newtonsoft.Json;

namespace AsaTeb.Persistence.Helpers
{
    public static class HttpClientManager
    {
        private const string BaseUrl = "https://app.ifs.aero/EternalBlue/";

        public static async Task<IEnumerable<Tech>?> ResolveUrl(string url)
        {
            //IEnumerable<T>? entities = new List<T>();
            using var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var res = await client.GetAsync(url);

            res.EnsureSuccessStatusCode();

            if (!res.IsSuccessStatusCode) return new List<Tech>();

            var techResponse = await res.Content.ReadAsStringAsync();
            var entities = JsonConvert.DeserializeObject<IEnumerable<Tech>>(techResponse);

            return entities;

        }
    }

    public class Tech
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }
    }
}
