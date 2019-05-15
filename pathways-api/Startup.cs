namespace pathways_api
{
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using pathways_common.Core;

    public class Startup : PathwaysStartup
    {
        public Startup(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureStandardStack(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            
            app.UseMvc();
        }

        protected override void AddEntityFramework(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(c => c.UseNpgsql(this.Configuration.GetConnectionString("LearningTogether")))
                .BuildServiceProvider();
        }

        protected override void AddAdditionalServices(IServiceCollection services)
        {
            services.AddAutoMapper();
        }
    }
}