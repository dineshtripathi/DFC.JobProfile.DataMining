using System;

namespace DFC.JobProfile.DataAccess
{
    using Newtonsoft.Json;

    public class SfJobProfileOdata
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("LastModified")]
        public string LastModified { get; set; }
        [JsonProperty("PublicationDate")]
        public string PublicationDate { get; set; }
        [JsonProperty("ExpirationDate")]
        public string ExpirationDate { get; set; }
        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }
        [JsonProperty("UrlName")]
        public string UrlName { get; set; }
        [JsonProperty("IsLMISalaryFeedOverriden")]
        public string IsLMISalaryFeedOverriden { get; set; }
        [JsonProperty("MinimumHours")]
        public string MinimumHours { get; set; }
        [JsonProperty("WhatYouWillDo")]
        public string WhatYouWillDo { get; set; }
        [JsonProperty("Salary")]
        public string Salary { get; set; }
        [JsonProperty("SalaryRange")]
        public string SalaryRange { get; set; }
        [JsonProperty("Overview")]
        public string Overview { get; set; }
        [JsonProperty("BAUSystemOverrideUrl")]
        public string BAUSystemOverrideUrl { get; set; }
        [JsonProperty("CourseKeywords")]
        public string CourseKeywords { get; set; }
        [JsonProperty("CareerPathAndProgression")]
        public string CareerPathAndProgression { get; set; }
        [JsonProperty("DoesNotExistInBAU")]
        public string DoesNotExistInBAU { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("HowToBecome")]
        public string HowToBecome { get; set; }
        [JsonProperty("MaximumHours")]
        public string MaximumHours { get; set; }
        [JsonProperty("WorkingHoursPatternsAndEnvironment")]
        public string WorkingHoursPatternsAndEnvironment { get; set; }
        [JsonProperty("SalaryExperienced")]
        public string SalaryExperienced { get; set; }
        [JsonProperty("Skills")]
        public string Skills { get; set; }
        [JsonProperty("SalaryStarter")]
        public string SalaryStarter { get; set; }
        [JsonProperty("AlternativeTitle")]
        public string AlternativeTitle { get; set; }
    }
}
