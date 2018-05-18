namespace DFC.JobProfile.Dapper.Dapper
{
    using System;
    using System.Data.Common;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    using Interface;

    public abstract class BaseRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ISecurityContextProvider _securityContextProvider;

        protected BaseRepository( IDbConnectionFactory connectionFactory) : this(connectionFactory, null)
        {
        }

        protected BaseRepository(IDbConnectionFactory connectionFactory, ISecurityContextProvider securityContextProvider)
        {
            _connectionFactory = connectionFactory;
            _securityContextProvider = securityContextProvider;
           
        }


        protected async Task<T> WithConnection<T>(Func<DbConnection, Task<T>> getData, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection())
                {

                    // Asynchronously open a connection to the database
                    await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                    var result =  await getData(connection).ConfigureAwait(false);
                    connection.Close();
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                //throw ExceptionMapper.Map(ex);
                throw;
            }
        }

    }


    public interface ISecurityContextProvider
    {
        IPrincipal Principal { get; set; }
    }

}
