using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amalgam.App.HttpApi.Authorization;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Contracts.Services;
using Amalgam.Core.Entities;
using Amalgam.Core.Handlers;
using Amalgam.Persistence.Context;
using Amalgam.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Amalgam.App.HttpApi
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
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Amalgam.App.HttpApi", Version = "v1" });
            });

            services.AddScoped<IGiftRepository, GiftRepository>();
            services.AddScoped<IGiftHandler, GiftHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserHandler, UserHandler>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactHandler, ContactHandler>();

            services.AddTransient<TokenService>();
            services.AddTransient<IPasswordHashService, PasswordHashService>();

            services.AddDbContext<AmalgamContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });


            services.Configure<AuthorizationConfig>(Configuration.GetSection("Authorization"));
            var secret = Convert.FromBase64String(Configuration.GetSection("Authorization").GetValue<string>("Secret"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(secret),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amalgam.App.HttpApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(cors => { 
                cors.AllowAnyOrigin();
                cors.AllowAnyHeader();
                cors.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}