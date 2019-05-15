namespace pathways_api
{
    using System;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using pathways_common.Core;
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
            base.ConfigurePathwaysServices(services);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.ConfigurePathways(app, env);
        }

        protected override void AddEntityFramework(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(c => c.UseNpgsql(this.Configuration.GetConnectionString("Pathways")))
                .BuildServiceProvider();
        }
    }
}