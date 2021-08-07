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
    public class FlagApplicationService : ApplicationServiceBase<Flag, FlagDto>, IFlagApplicationService
    {
        protected readonly IFlagService service;

        public FlagApplicationService(IFlagService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
        }

    }
}
