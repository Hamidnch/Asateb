//using Newtonsoft.Json;
//using System.Net.Http.Headers;

//namespace AsaTeb.Common.Helpers
//{
//    public static class HttpClientManager
//    {
//        private const string BaseUrl = "https://app.ifs.aero/EternalBlue/";

//        public static async Task<IEnumerable<T>?> ResolveUrl<T>(string url)
//        {
//            //IEnumerable<T>? entities = new List<T>();
//            using var client = new HttpClient();
//            client.BaseAddress = new Uri(BaseUrl);
//            client.DefaultRequestHeaders.Clear();
//            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            var res = await client.GetAsync(url);

//            res.EnsureSuccessStatusCode();

//            if (!res.IsSuccessStatusCode) return new List<T>();

//            var techResponse = await res.Content.ReadAsStringAsync();
//            var entities = JsonConvert.DeserializeObject<IEnumerable<T>>(techResponse);

//            return entities;

//        }
//    }
//}