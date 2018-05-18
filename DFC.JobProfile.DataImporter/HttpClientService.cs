namespace DFC.JobProfile.DataImporter
{
    using System.Net.Http;

    public class HttpClientService : IHttpClientService
    {
        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns></returns>
        public HttpClient GetHttpClient()
        {
            return new HttpClient();
        }
    }
}