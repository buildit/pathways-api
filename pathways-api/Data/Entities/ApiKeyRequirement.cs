namespace pathways_api.Data.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;

    public class ApiKeyRequirement : IAuthorizationRequirement
    {
        public IReadOnlyList<string> ApiKeys { get; set; }

        public ApiKeyRequirement(IEnumerable<string> apiKeys)
        {
            ApiKeys = apiKeys?.ToList() ?? new List<string>();
        }
    }
}