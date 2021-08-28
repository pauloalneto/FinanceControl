using Common.Domain.Base;
using FinanceControl.Domain.Entity;
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

        public virtual async Task<IEnumerable<UserRole>> GetByFilters()
        {
            var result = this.rep.GetAllWithFilters();
            return await this.rep.ToListAsync(result);
        }
    }
}
