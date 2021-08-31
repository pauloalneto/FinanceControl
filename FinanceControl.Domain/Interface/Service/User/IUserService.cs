using Common.Domain.Interface;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Interface.Service
{
    public interface IUserService : IServiceBase<User, UserFilter>
    {
    }
}
