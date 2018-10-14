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
using Models.Input;
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
            services.AddTransient<ITapeReviewRepository, TapeReviewRepository>();
            services.AddTransient<ITapeReviewService, TapeReviewService>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IFriendService, FriendService>();
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
            
            
            // automapper to map entities to dtos and inputmodels to entities
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Tape, TapeDto>();
                cfg.CreateMap<Tape, TapeDetailsDto>();
                cfg.CreateMap<TapeInputModel, Tape>()
                    .ForMember(tape => tape.DateCreated, opt => opt.UseValue(DateTime.Now))
                    .ForMember(tape => tape.DateModified, opt => opt.UseValue(DateTime.Now));
                cfg.CreateMap<Review, ReviewDto>();
                cfg.CreateMap<ReviewInputModel, Review>()
                    .ForMember(review => review.DateCreated, opt => opt.UseValue(DateTime.Now))
                    .ForMember(review => review.DateModified, opt => opt.UseValue(DateTime.Now));
                cfg.CreateMap<Friend, FriendDto>();
                cfg.CreateMap<Friend, FriendDetailsDto>();
                cfg.CreateMap<FriendInputModel, Friend>()
                    .ForMember(friend => friend.DateCreated, opt => opt.UseValue(DateTime.Now))
                    .ForMember(friend => friend.DateModified, opt => opt.UseValue(DateTime.Now));
            });
        }
    }
}
