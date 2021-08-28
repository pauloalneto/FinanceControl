using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class UserRoleBase
    {
        public UserRoleBase() { }

        public UserRoleBase(int userId, int roleId) {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        public int UserId { get; protected set; }
        public int RoleId { get; protected set; }
    }
}
