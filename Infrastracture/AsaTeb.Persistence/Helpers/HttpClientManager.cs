using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Domain.Technologies;
using Newtonsoft.Json;

namespace AsaTeb.Persistence.Helpers
{
    public static class HttpClientManager
    {
        private const string BaseUrl = "https://app.ifs.aero/EternalBlue/";

        public static async Task<IEnumerable<T>?> ResolveUrlAsync<T>(string url)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var res = await client.GetAsync(url);

            res.EnsureSuccessStatusCode();

            if (!res.IsSuccessStatusCode) return new List<T>();

            var response = await res.Content.ReadAsStringAsync();
            var entities = JsonConvert.DeserializeObject<IEnumerable<T>>(response);

            return entities;

        }

        //public static async Task<IEnumerable<TechnologyDto>?> ResolveUrl(string url)
        //{
        //    //IEnumerable<T>? entities = new List<T>();
        //    using var client = new HttpClient();
        //    client.BaseAddress = new Uri(BaseUrl);
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var res = await client.GetAsync(url);

        //    res.EnsureSuccessStatusCode();

        //    if (!res.IsSuccessStatusCode) return new List<TechnologyDto>();

        //    var techResponse = await res.Content.ReadAsStringAsync();
        //    var entities = JsonConvert.DeserializeObject<IEnumerable<TechnologyDto>>(techResponse);

        //    return entities;

        //}
    }
}
