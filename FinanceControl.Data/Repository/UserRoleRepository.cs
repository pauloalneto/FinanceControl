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
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<UserRole> GetAllWithFilters()
        {
            return this.GetAll();
        }
    }
}
