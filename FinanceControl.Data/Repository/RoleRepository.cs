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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<Role> GetAllWithFilters(RoleFilter filters)
        {
            return this.GetAll();
        }

        public Task<dynamic> GetDataCustom(RoleFilter filters)
        {
            throw new NotImplementedException();
        }
    }
}
