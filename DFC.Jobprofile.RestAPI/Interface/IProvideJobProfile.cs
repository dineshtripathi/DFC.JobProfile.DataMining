namespace DFC.Jobprofile.RestAPI.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProvideJobProfile
    {
        Task<ICollection<string>> GetJobProfileData();

    }
}