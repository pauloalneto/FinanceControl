using FinanceControl.Application.App;
using FinanceControl.Application.Interfaces;
using FinanceControl.Data.Repository;
using FinanceControl.Domain.Interface.Repository;
using FinanceControl.Domain.Interface.Service;
using FinanceControl.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceControl.Api
{
    public static partial class ConfigContainerFinanceControl
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IFlagApplicationService, FlagApplicationService>();
            services.AddScoped<IFlagService, FlagService>();
            services.AddScoped<IFlagRepository, FlagRepository>();

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
