namespace DFC.JobProfile.Dapper.Dapper.Interface
{
    using DFC.JobProfile.DataAccess;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDapperCRUD
    {
        Task<object> Insert(ICollection<SfJobProfileOdata> oDataCollection);
        Task<object> Update(ICollection<SfJobProfileOdata> oDataCollection);
        Task<object> IfExistJobProfileId(string id);
    }
}