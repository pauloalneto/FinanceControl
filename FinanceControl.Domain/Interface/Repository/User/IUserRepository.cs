using Common.Domain.Interface;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Domain.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetAllWithFilters(UserFilter filters);
        Task<dynamic> GetDataCustom(UserFilter filters);
    }
}
