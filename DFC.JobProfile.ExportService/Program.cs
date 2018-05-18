using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DFC.JobProfile.ExportService
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using Autofac;
    using Dapper.Dapper.Interface;
    using DataAccess;
    using DataImporter;
    using global::Dapper;
    using Newtonsoft.Json;

    class Program
    {
        private const string CONTENT_TYPE = "application/json";
        static void  Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-SF-Service-Request", "true");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));

            var re = httpClient.GetStringAsync(new Uri(ConfigurationManager.AppSettings.Get("DFC.JobProfile.Endpoint"))).GetAwaiter().GetResult();

           
            var scope = AutoFacContainerConfig.RegisterLifetimeScope();
            {
                using (var resolveEntity = scope.BeginLifetimeScope())
                {
                    var sfJpData = resolveEntity.Resolve<ISiteFinityJobProfileImportData>();
                    var client=sfJpData.GetAllJobProfileData<SfJobProfileOdata>(new Uri(ConfigurationManager.AppSettings.Get("DFC.JobProfile.Endpoint"))).Result;

                    //Bulk insert into Dapper SQL
                    var dap = resolveEntity.Resolve<IDapperCRUD>();
                    var connection=dap.Insert(client.Value.ToList());

                    //connection.Open();
                    //var insertQuery =@"INSERT INTO [dbo].[SitefinityJobProfileData]([Id],[LastModified],[PublicationDate],[ExpirationDate],[UrlName],[IsLMISalaryFeedOverriden],[MinimumHours] ,[WhatYouWillDo],[Salary],[SalaryRange],[Overview],[BAUSystemOverrideUrl],[CourseKeywords] ,[CareerPathAndProgression],[DoesNotExistInBAU],[Title],[HowToBecome],[MaximumHours],[WorkingHoursPatternsAndEnvironment],[SalaryExperienced],[Skills],[SalaryStarter],[AlternativeTitle])
                    //values  (@Id,@LastModified,@PublicationDate,@ExpirationDate,@UrlName,@IsLMISalaryFeedOverriden,@MinimumHours,@WhatYouWillDo,@Salary,@SalaryRange,@Overview,@BAUSystemOverrideUrl,@CourseKeywords,@CareerPathAndProgression,@DoesNotExistInBAU,@Title,@HowToBecome,@MaximumHours,@WorkingHoursPatternsAndEnvironment,@SalaryExperienced,@Skills,@SalaryStarter,@AlternativeTitle )";
                    //foreach (var c in client.Value)
                    //{
                    //    var cdata = c;
                    //    var odata = new SfJobProfileOdata()
                    //    {
                    //        Id = cdata.Id,
                    //        AlternativeTitle = cdata.AlternativeTitle,
                    //        BAUSystemOverrideUrl = cdata.BAUSystemOverrideUrl,
                    //        WhatYouWillDo =HttpUtility.HtmlDecode(cdata.WhatYouWillDo),
                    //        HowToBecome = HttpUtility.HtmlDecode(cdata.HowToBecome),
                    //        CareerPathAndProgression = HttpUtility.HtmlDecode(cdata.CareerPathAndProgression),
                    //        Salary = HttpUtility.HtmlDecode(cdata.Salary),
                    //        WorkingHoursPatternsAndEnvironment =
                    //            HttpUtility.HtmlDecode(cdata.WorkingHoursPatternsAndEnvironment),
                    //        Skills =HttpUtility.HtmlDecode(cdata.Skills),
                    //        SalaryRange = cdata.SalaryStarter,
                    //        LastModified = cdata.LastModified,
                    //        PublicationDate = cdata.PublicationDate,
                    //        ExpirationDate = cdata.ExpirationDate,
                    //        DateCreated = cdata.DateCreated,
                    //        UrlName = cdata.UrlName,
                    //        IsLMISalaryFeedOverriden = cdata.IsLMISalaryFeedOverriden,
                    //        MinimumHours = cdata.MinimumHours,
                    //        MaximumHours = cdata.MaximumHours,
                    //        SalaryStarter = cdata.SalaryStarter,
                    //        CourseKeywords = cdata.CourseKeywords,
                    //        DoesNotExistInBAU = cdata.DoesNotExistInBAU,
                    //        Title = cdata.Title,
                    //        SalaryExperienced = cdata.SalaryExperienced
                    //    };
                    //    connection.ExecuteAsync(insertQuery, odata).ConfigureAwait(false);
                    //}
                    //connection.Close();
                }
            }
        }
    }
}
