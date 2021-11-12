using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Common.Domain.Base;
using Common.Domain.Helpers;
using FinanceControl.Application.Config;
using FinanceControl.CrossCutting.Auth;
using FinanceControl.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace FinanceControl.Sso.Api
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
            services.AddControllers();

            services.AddDbContext<DbContextFinanceControl>(options =>
                options.UseSqlServer(Configuration.GetSection("ConfigConnectionString:Default").Value));


            services.AddAutoMapper(AutoMapperConfigFinanceControl.RegisterMappings());

            //Services Configuration
            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));

            ConfigContainerFinanceControl.Config(services);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityConfig.GetSecret()));
                paramsValidation.ValidAudiences = new List<string> { "http://localhost:4200", "https://localhost:44378", "http://localhost:52078" };
                paramsValidation.ValidIssuer = "https://localhost:44304/";

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            //// Setting OAuth2 configuration
            //services.AddAuthentication(o =>
            //{
            //    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.RequireHttpsMetadata = false;
            //    o.SaveToken = true;
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityConfig.GetSecret())),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudiences = new List<string> { "http://localhost:4200", "https://localhost:44378", "http://localhost:52078" },
            //        ValidateLifetime = true,
            //    };
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowStackOrigin",
                    builder => builder
                    .WithOrigins("http://localhost:4200", "https://localhost:44378", "http://localhost:52078")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
    }
}
