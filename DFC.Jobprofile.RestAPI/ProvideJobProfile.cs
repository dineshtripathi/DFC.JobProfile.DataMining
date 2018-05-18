using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Jobprofile.RestAPI
{
    using Interface;

    public class ProvideJobProfile:IProvideJobProfile
    {
        #region Implementation of IProvideJobProfile

        public Task<ICollection<string>> GetJobProfileData()
        {
            return null;
        }

        #endregion
    }
}
