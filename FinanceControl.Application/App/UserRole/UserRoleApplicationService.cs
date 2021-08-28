using AutoMapper;
using Common.Domain.Base;
using Common.Domain.Interface;
using FinanceControl.Application.Interfaces;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Interface.Service;
using FinanceControl.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Application.App
{
    public class UserRoleApplicationService : ApplicationServiceBase<UserRole, UserRoleDto>, IUserRoleApplicationService
    {
        protected readonly IUserRoleService service;

        public UserRoleApplicationService(IUserRoleService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
        }

    }
}
