using Common.Orm.Base;
using FinanceControl.Data.Context;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceControl.Data.Repository
{
    public class FlagRepository : Repository<Flag>, IFlagRepository
    {
        public FlagRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<Flag> GetAllWithFilters()
        {
            return this.GetAll();
        }
    }
}
