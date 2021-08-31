using Common.Orm.Base;
using FinanceControl.Data.Context;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using FinanceControl.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Data.Repository
{
    public class FlagRepository : Repository<Flag>, IFlagRepository
    {
        public FlagRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<Flag> GetAllWithFilters(FlagFilter filters)
        {
            return this.GetAll();
        }

        public Task<dynamic> GetDataCustom(FlagFilter filters)
        {
            throw new NotImplementedException();
        }
    }
}
