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
        // This method gets called by the runtime. Use this method to add services to the container.
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureStandardStack(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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