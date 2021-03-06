namespace pathways_api
{
    using System;
    using AutoMapper;
    using Data;
    using Data.Entities;
    using Handlers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using pathways_common.Core;
    using pathways_common.Interfaces.Services;
    using pathways_common.Services;
    using Services;
    using Services.Interfaces;

    public class Startup : PathwaysStartup
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigurePathwaysServices(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleTypeService, RoleTypeService>();
            services.AddScoped<IRoleLevelService, RoleLevelService>();
            services.AddScoped<ISkillLevelService, SkillLevelService>();
            services.AddScoped<ISkillTypeService, SkillTypeService>();
            services.AddScoped<ISkillTypeLevelService, SkillTypeLevelService>();
            services.AddScoped<IRoleLevelRuleService, RoleLevelRuleService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IMSGraphService, MicrosoftGraphService>();
            services.Configure<DomoClient>(Configuration.GetSection("DomoClient"));

            IConfigurationSection domoProviderConfig = this.Configuration.GetSection("DomoProvider");
            services.Configure<DomoProvider>(domoProviderConfig);

            services.AddAuthorization(authConfig =>
            {
                authConfig.AddPolicy("ApiKeyPolicy",
                    policyBuilder =>
                        policyBuilder.AddRequirements(new ApiKeyRequirement(new[] { domoProviderConfig["ApiKey"] })));
            });

            services.AddSingleton<IAuthorizationHandler, ApiKeyRequirementHandler>();
            services.AddScoped<IUserDataService, userDataService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            this.ConfigurePathways(app, env);
        }

        protected override void AddEntityFramework(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(c => c.UseNpgsql(this.Configuration.GetConnectionString("Pathways")))
                .BuildServiceProvider();
        }
    }
}