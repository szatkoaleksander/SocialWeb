using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using SocialWeb.Infrastructure.Mapper;
using SocialWeb.Infrastructure.IoC.Modules;
using SocialWeb.Infrastructure.IoC;
using SocialWeb.Infrastructure.EF;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace SocialWeb.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(AutoMapperConfig.Initialize());

            services.AddCors();

            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<EFContext>();  
            
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
            
            services.AddAuthentication(options =>  
            {  
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
            })  
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("000_cat_test_key_123")),  
            
                    ValidateIssuer = true,  
                    ValidIssuer = "http://localhost:5000",
            
                    ValidateAudience = false,   
                    ValidateLifetime = true,  
            
                    ClockSkew = TimeSpan.Zero 
                };
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<SqlModule>();
            builder.RegisterModule<ServiceModule>();
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());   

            app.UseMvc();
            app.UseAuthentication();
            
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
