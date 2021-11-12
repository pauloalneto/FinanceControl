using Common.Domain.Model;
using FinanceControl.Application.App;
using FinanceControl.Application.Interfaces;
using FinanceControl.Data.Repository;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using FinanceControl.Domain.Interface.Repository;
using FinanceControl.Domain.Interface.Service;
using FinanceControl.Domain.Service;
using FinanceControl.Sso.Api.Interfaces;
using FinanceControl.Sso.Api.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceControl.Sso
{
    public static partial class ConfigContainerFinanceControl
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<CurrentUser>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRoleApplicationService, RoleApplicationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IUserRoleApplicationService, UserRoleApplicationService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }
    }
}
