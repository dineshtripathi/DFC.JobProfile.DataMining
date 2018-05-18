namespace DFC.JobProfile.DataImporter
{
    using System.Net.Http;

    public interface IHttpClientService
    {
        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns></returns>
        HttpClient GetHttpClient();
    }
}