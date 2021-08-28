using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class UserRole : UserRoleBase
    {
        public User User { get; private set; }
        public Role Role { get; private set; }

        public UserRole(int userId, int roleId) : base(userId, roleId)
        {
        }
    }
}
