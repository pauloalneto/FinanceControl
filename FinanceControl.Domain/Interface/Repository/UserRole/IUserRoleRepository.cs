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
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        IQueryable<UserRole> GetAllWithFilters(UserRoleFilter filters);
        Task<dynamic> GetDataCustom(UserRoleFilter filters);
    }
}
