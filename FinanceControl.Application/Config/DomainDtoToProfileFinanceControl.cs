using FinanceControl.Domain.Entity;
using FinanceControl.Dto.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Application.Config
{
    public class DomainDtoToProfileFinanceControl : AutoMapper.Profile
    {
        public DomainDtoToProfileFinanceControl()
        {
            CreateMap(typeof(Flag), typeof(FlagDto)).ReverseMap();
            CreateMap(typeof(User), typeof(UserDto)).ReverseMap();
        }
    }
}
