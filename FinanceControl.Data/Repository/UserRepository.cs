using Common.Orm.Base;
using FinanceControl.Data.Context;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<User> GetAllWithFilters()
        {
            var users = this.GetAll().Include(_ => _.CollectionUserRole).ThenInclude(_ => _.Role);

            return users;
        }
    }
}
