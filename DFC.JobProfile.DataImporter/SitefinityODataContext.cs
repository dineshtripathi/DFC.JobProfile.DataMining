namespace DFC.JobProfile.DataImporter
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using DataAccess;
    using Newtonsoft.Json;

    public class SitefinityODataContext : IOdataContext
    {
        private const string CONTENT_TYPE = "application/json";
        private readonly IHttpClientService httpClientService;

        public SitefinityODataContext(IHttpClientService httpClient)
        {
            httpClientService = httpClient;
        }
        public async Task<HttpClient> GetHttpClientAsync()
        {

            var httpClient = httpClientService.GetHttpClient();
            httpClient.DefaultRequestHeaders.Add("X-SF-Service-Request", "true");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));
            return httpClient;
        }

        public async Task<PagedOdataResult<T>> GetResult<T>(Uri requestUri) where T : class, new()
        {
            using (var client = await GetHttpClientAsync())
            {
                try
                {
                    var result = await client.GetStringAsync(requestUri);
                    var jsonData = JsonConvert.DeserializeObject<PagedOdataResult<T>>(result);
                    return jsonData;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Not valie Uri : {requestUri} . Expception Thrown at :{e}");
                    throw;
                }
            }
        }

        public async Task<string> PostAsync<T>(Uri requestUri, T data) where T : class, new()
        {
            using (var client = await GetHttpClientAsync())
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, CONTENT_TYPE);
                var result = await client.PostAsync(requestUri, content);
                var jsonContent = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(jsonContent);
                }

                return jsonContent;
            }
        }

        public async Task<string> PutAsync(Uri requestUri, string relatedEntityLink)
        {
            using (var client = await GetHttpClientAsync())
            {
                var content = new StringContent(relatedEntityLink, Encoding.UTF8, CONTENT_TYPE);
                var result = await client.PutAsync(requestUri, content);
                var jsonContent = await result.Content.ReadAsStringAsync();


                if (!result.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(jsonContent);
                }

                return jsonContent;
            }
        }
    }
}