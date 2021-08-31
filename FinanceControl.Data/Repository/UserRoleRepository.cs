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
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<UserRole> GetAllWithFilters(UserRoleFilter filters)
        {
            return this.GetAll();
        }

        public Task<dynamic> GetDataCustom(UserRoleFilter filters)
        {
            throw new NotImplementedException();
        }
    }
}
