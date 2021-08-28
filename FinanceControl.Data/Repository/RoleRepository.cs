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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<Role> GetAllWithFilters()
        {
            return this.GetAll();
        }
    }
}
