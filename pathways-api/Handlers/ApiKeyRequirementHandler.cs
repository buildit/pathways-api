namespace pathways_api.Handlers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Options;

    public class ApiKeyRequirementHandler : AuthorizationHandler<ApiKeyRequirement>
    {
        private readonly IOptions<DomoProvider> providerOptions;
        public const string API_KEY_HEADER_NAME = "X-API-KEY";

        public ApiKeyRequirementHandler(IOptions<DomoProvider> providerOptions)
        {
            this.providerOptions = providerOptions;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            SucceedRequirementIfApiKeyPresentAndValid(context, requirement);
            return Task.CompletedTask;
        }

        private void SucceedRequirementIfApiKeyPresentAndValid(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            if (!(context.Resource is AuthorizationFilterContext authorizationFilterContext)) return;

            string apiKey = authorizationFilterContext.HttpContext.Request.Headers[ApiKeyRequirementHandler.API_KEY_HEADER_NAME].FirstOrDefault();
            if (apiKey != null && requirement.ApiKeys.Any(requiredApiKey => apiKey == requiredApiKey))
            {
                context.Succeed(requirement);
            }
        }
    }
}