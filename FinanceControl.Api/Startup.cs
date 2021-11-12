using Common.API.Extensions;
using Common.Domain.Base;
using Common.Domain.Helpers;
using FinanceControl.Application.Config;
using FinanceControl.CrossCutting.Auth;
using FinanceControl.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceControl.Api
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
            //Camelcase para json
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.WriteIndented = false;
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.Converters.Add(new StringJsonConverterHelper());
            });

            services.AddDbContext<DbContextFinanceControl>(options =>
                options.UseSqlServer(Configuration.GetSection("ConfigConnectionString:Default").Value));


            services.AddSingleton<IConfiguration>(Configuration);

            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.SaveToken = true;
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityConfig.GetSecret())),
                        ClockSkew = TimeSpan.Zero,
                        ValidAudience = "http://localhost:52078",
                        ValidIssuer = "https://localhost:44304/",
                        
                    };
                    o.Events = new JwtBearerEvents()
                    {
                        OnTokenValidated = ProcessAfterTokenValidation  
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowStackOrigin",
                    builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            });

            services.AddAutoMapper(AutoMapperConfigFinanceControl.RegisterMappings());
            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
            ConfigContainerFinanceControl.Config(services);

            services.AddAuthorizationPolicy(ProfileCustom.Define);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Cultue
            var supportedCultures = new[]
            {
                new CultureInfo("pt-BR"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowStackOrigin");
            app.UseAuthentication();
            app.UseAuthorization();
            app.AddTokenMiddlewareCustom();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        public Task ProcessAfterTokenValidation(TokenValidatedContext tokenValidatedContext)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtSecurityTokenHandler.WriteToken(tokenValidatedContext.SecurityToken);

            return Task.CompletedTask;
        }
    }
}
 