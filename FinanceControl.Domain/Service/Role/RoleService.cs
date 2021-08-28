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
    public class RoleService : ServiceBase<Role>, IRoleService
    {
        protected readonly IRoleRepository rep;

        public RoleService(IRoleRepository rep)
        {
            this.rep = rep;
        }

        public virtual async Task<IEnumerable<Role>> GetByFilters()
        {
            var result = this.rep.GetAllWithFilters();
            return await this.rep.ToListAsync(result);
        }
    }
}
