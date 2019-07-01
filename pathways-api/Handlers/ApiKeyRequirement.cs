namespace pathways_api.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;

    public class ApiKeyRequirement : IAuthorizationRequirement
    {
        public IReadOnlyList<string> ApiKeys { get; set; }

        public ApiKeyRequirement(IEnumerable<string> apiKeys)
        {
            this.ApiKeys = apiKeys?.ToList() ?? new List<string>();
        }
    }
}