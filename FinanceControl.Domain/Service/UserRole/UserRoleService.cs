using Common.Domain;
using Common.Domain.Base;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using FinanceControl.Domain.Interface.Repository;
using FinanceControl.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Domain.Service
{
    public class UserRoleService : ServiceBase<UserRole>, IUserRoleService
    {
        protected readonly IUserRoleRepository rep;

        public UserRoleService(IUserRoleRepository rep)
        {
            this.rep = rep;
        }

        public virtual async Task<IEnumerable<UserRole>> GetByFilters(UserRoleFilter filters)
        {
            var result = this.rep.GetAllWithFilters(filters);
            return await this.rep.ToListAsync(result);
        }
    }
}
