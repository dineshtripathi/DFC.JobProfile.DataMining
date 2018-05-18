using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.JobProfile.DataImporter
{
    using DataAccess;

    public class SiteFinityJobProfileImportData:ISiteFinityJobProfileImportData
    {
        private readonly IOdataContext odataContext;
        #region Implementation of ISiteFinityJobProfileOData

        public SiteFinityJobProfileImportData(IOdataContext odataContext)
        {
            this.odataContext = odataContext;
        }
        public Task<PagedOdataResult<T>> GetAllJobProfileData<T>(System.Uri requestUri) where T:class , new ()
        {
           return odataContext.GetResult<T>(requestUri);
        }

        #endregion
    }
}
