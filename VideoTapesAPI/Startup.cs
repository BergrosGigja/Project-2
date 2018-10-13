using System;
using System.Collections.Generic;
using System.Linq;
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
using Models.Dtos;
using Models.Entity;
using Repositories;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using VideoTapesAPI.Exceptions;

namespace VideoTapesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            // database
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlite("Data Source=../Repositories/VideoTapesGaloreDb.db",
                    x => x.MigrationsAssembly("VideoTapesAPI")));
            
            // dependancy injection
            services.AddTransient<ISeedRepository, SeedRepository>();
            services.AddTransient<ISeedService, SeedService>();
            services.AddTransient<ITapeRepository, TapeRepository>();
            services.AddTransient<ITapeService, TapeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // global exception handler
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseMvc();
            
            
            // automapper to map entities to Dtos
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Tape, TapeDto>();
                    
                
            });
        }
    }
}
