using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using pathways_api.Data;
using pathways_api.Services;
using pathways_api.Services.Interfaces;

namespace pathways_api
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }
        
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            //this.Configuration = configuration;
            
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container and map configuration to object
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(c => c.UseNpgsql(this.Configuration.GetConnectionString("Pathways")))
                .BuildServiceProvider();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddAutoMapper();
            
            // Adds services required for using options.
            services.AddOptions();
            
            // Register the IConfiguration instance which options binds against.
            services.Configure<DomoClient>(Configuration.GetSection("DomoClient"));
            
            // Add framework services.
            services.AddMvc();
             
            // configure DI for application services
            services.AddScoped<IUserDataService, userDataService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
