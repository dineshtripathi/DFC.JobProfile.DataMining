namespace DFC.JobProfile.DataImporter
{
    using System;
    using System.Threading.Tasks;
    using DataAccess;

    public interface ISiteFinityJobProfileImportData
    {
        Task<PagedOdataResult<T>> GetAllJobProfileData<T>(Uri requestUri) where T:class , new();

    }
}