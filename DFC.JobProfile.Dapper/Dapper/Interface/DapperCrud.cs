namespace DFC.JobProfile.Dapper.Dapper.Interface
{
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Threading.Tasks;
    using System.Web;
    using DataAccess;
    using global::Dapper;

    public class DapperCrud : IDapperCRUD
    {
        private readonly IDbConnectionFactory _connection;
        private readonly DbConnection _dapperConnection;
        #region Implementation of IDapperCRUD

        public DapperCrud(IDbConnectionFactory connection)
        {
            this._connection = connection;
            _dapperConnection=connection.GetConnection();
        }
        public Task<object> Insert(ICollection<SfJobProfileOdata> oDataCollection)
        {
            const string insertQuery = @"INSERT INTO [dbo].[SitefinityJobProfileData]([Id],[LastModified],[PublicationDate],[ExpirationDate],[UrlName],[IsLMISalaryFeedOverriden],[MinimumHours] ,[WhatYouWillDo],[Salary],[SalaryRange],[Overview],[BAUSystemOverrideUrl],[CourseKeywords] ,[CareerPathAndProgression],[DoesNotExistInBAU],[Title],[HowToBecome],[MaximumHours],[WorkingHoursPatternsAndEnvironment],[SalaryExperienced],[Skills],[SalaryStarter],[AlternativeTitle])
                    values  (@Id,@LastModified,@PublicationDate,@ExpirationDate,@UrlName,@IsLMISalaryFeedOverriden,@MinimumHours,@WhatYouWillDo,@Salary,@SalaryRange,@Overview,@BAUSystemOverrideUrl,@CourseKeywords,@CareerPathAndProgression,@DoesNotExistInBAU,@Title,@HowToBecome,@MaximumHours,@WorkingHoursPatternsAndEnvironment,@SalaryExperienced,@Skills,@SalaryStarter,@AlternativeTitle )";
            _dapperConnection.Open();
            foreach (var cdata in oDataCollection)
            {
                var odata = new SfJobProfileOdata()
                {
                    Id = cdata.Id,
                    AlternativeTitle = cdata.AlternativeTitle,
                    BAUSystemOverrideUrl = cdata.BAUSystemOverrideUrl,
                    WhatYouWillDo = HttpUtility.HtmlDecode(cdata.WhatYouWillDo),
                    HowToBecome = HttpUtility.HtmlDecode(cdata.HowToBecome),
                    CareerPathAndProgression = HttpUtility.HtmlDecode(cdata.CareerPathAndProgression),
                    Salary = HttpUtility.HtmlDecode(cdata.Salary),
                    WorkingHoursPatternsAndEnvironment =
                        HttpUtility.HtmlDecode(cdata.WorkingHoursPatternsAndEnvironment),
                    Skills = HttpUtility.HtmlDecode(cdata.Skills),
                    SalaryRange = cdata.SalaryStarter,
                    LastModified = cdata.LastModified,
                    PublicationDate = cdata.PublicationDate,
                    ExpirationDate = cdata.ExpirationDate,
                    DateCreated = cdata.DateCreated,
                    UrlName = cdata.UrlName,
                    IsLMISalaryFeedOverriden = cdata.IsLMISalaryFeedOverriden,
                    MinimumHours = cdata.MinimumHours,
                    MaximumHours = cdata.MaximumHours,
                    SalaryStarter = cdata.SalaryStarter,
                    CourseKeywords = cdata.CourseKeywords,
                    DoesNotExistInBAU = cdata.DoesNotExistInBAU,
                    Title = cdata.Title,
                    SalaryExperienced = cdata.SalaryExperienced
                };
                _dapperConnection.ExecuteAsync(insertQuery, odata).ConfigureAwait(false);
            }
            _dapperConnection.Close();
            return null;
        }

        public Task<object> Update(ICollection<SfJobProfileOdata> oDataCollection)
        {
            return null;
        }

        public Task<object> IfExistJobProfileId(string id)
        {
            return null;
        }

        #endregion
    }
}