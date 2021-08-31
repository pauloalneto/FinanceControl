using Common.Orm.Base;
using FinanceControl.Data.Context;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using FinanceControl.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceControl.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContextFinanceControl context) : base(context)
        {

        }

        public IQueryable<User> GetAllWithFilters(UserFilter filters)
        {
            var users = this.GetAll().Include(_=>_.CollectionUserRole).ThenInclude(_=>_.Role);

            return users;
        }

        public async Task<dynamic> GetDataCustom(UserFilter filters)
        {
            var users = await ToListAsync(this.GetAllWithFilters(filters).Select(_ => new {
                _.UserId,
                _.Name,
                _.Email,
                roles = _.CollectionUserRole.Select(c => new { c.RoleId, c.Role.Name }).ToList()
            }));

            return users;
        }
    }
}
