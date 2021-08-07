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
    public class FlagService : ServiceBase<Flag>, IFlagService
    {
        protected readonly IFlagRepository rep;

        public FlagService(IFlagRepository rep)
        {
            this.rep = rep;
        }

        public virtual async Task<IEnumerable<Flag>> GetByFilters()
        {
            var result = this.rep.GetAllWithFilters();
            return await this.rep.ToListAsync(result);
        }
    }
}
