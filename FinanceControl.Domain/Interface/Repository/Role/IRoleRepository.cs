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
    public interface IRoleRepository : IRepository<Role>
    {
        IQueryable<Role> GetAllWithFilters(RoleFilter filters);
        Task<dynamic> GetDataCustom(RoleFilter filters);
    }
}
