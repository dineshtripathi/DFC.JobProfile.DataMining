using System.Data.Common;

namespace DFC.JobProfile.Dapper.Dapper.Interface
{
    public interface IDbConnectionFactory
    {
        DbConnection GetConnection();
    }



}