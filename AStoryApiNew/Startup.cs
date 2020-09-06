using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Dto.Model;
using Services.AuthenticationService;
using Services.ErrorLogService;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.CommonRepository;
using Repository.UserRepository;
using Swashbuckle;
using System.Runtime.InteropServices;
using Microsoft.OpenApi.Models;
using Repository.StoryRepository;
using Services.StoryServices;
using Services.EpisodeService;

namespace AStoryApiNew
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
            //added the firebase authenticstion middleware
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetValue<string>("Authentication:Authority");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetValue<string>("Authentication:ValidIssuer"),
                        ValidateAudience = true,
                        ValidAudience = Configuration.GetValue<string>("Authentication:ValidAudience"),
                        ValidateLifetime = true
                    };
                });

            services.Configure<Authentication>(Configuration.GetSection("Authentication"));

            services.AddOptions();

            services.AddControllers();

            SwaggerRegister(services);

            setDatabase(services);

            RegisterDbContext(services);

            RegisterRepos(services);

            RegisterServies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "A Story APi");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void RegisterServies(IServiceCollection service)
        {
            service.AddTransient(typeof(IAuthentication), typeof(AuthenticationService));
            service.AddTransient(typeof(IErrorLogService), typeof(ErrorLogService));
            service.AddTransient(typeof(IStotyService), typeof(StoryService));
            service.AddTransient(typeof(IEpisodeService), typeof(EpisodeService));
        }

        public virtual void setDatabase(IServiceCollection services)
        {
            services.AddDbContext<AStoryDatabaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        protected virtual void RegisterDbContext(IServiceCollection services)
        {
            services.AddScoped<DbContext, AStoryDatabaseContext>();
        }

        protected virtual void RegisterRepos(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IStoryRepository), typeof(StoryRepository));
        }

        protected virtual void SwaggerRegister(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "A Story APi", Version = "v1", });
            });
        }

    }
}
