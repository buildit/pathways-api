using System;
using System.Collections;
using System.Collections.Generic;

namespace pathways_api.Data.Mappers
{
    public class UserDataDto
    {
        public long UserId { get; set; }
        public string UserEmail { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public bool IsUserAdmin { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserTimezone { get; set; }
        public bool IsUserContractor { get; set; }
        public string UserTelephone { get; set; }
        public bool IsUserActive { get; set; }
        public bool HasAccessToAllFutureProjects { get; set; }
        public decimal UserHourlyRate { get; set; }
        public string UserDepartment { get; set; }
        public bool WantsNewsletterSubscription { get; set; }
        public DateTime UserUpdatedAt { get; set; }
        public bool IsUserProjectManager { get; set; }
        public decimal UserCostRate { get; set; }
        public double UserWeeklyCapacity { get; set; }
        public string Band { get; set; }
        public string Location { get; set; }
        public string UserRole { get; set; }
        public string Studio { get; set; }
        public string UserSampleData { get; set; }
        public double BatchId { get; set; }
        public DateTime BatchLastRan { get; set; }
    }
}