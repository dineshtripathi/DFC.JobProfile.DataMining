namespace DFC.JobProfile.DataImporter
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using DataAccess;

    public interface IOdataContext 
    {
        Task<HttpClient> GetHttpClientAsync();

        Task<PagedOdataResult<T>> GetResult<T>(Uri requestUri) where T : class, new();
        Task<string> PostAsync<T>(Uri requestUri, T data) where T : class, new();
        Task<string> PutAsync(Uri requestUri, string relatedEntityLink);
    }
}