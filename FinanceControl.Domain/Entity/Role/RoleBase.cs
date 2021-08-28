using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class RoleBase
    {
        public RoleBase()
        {

        }
        public RoleBase(int roleId)
        {
            this.RoleId = roleId;
        }

        public int RoleId { get; protected set; }
        public string Name { get; protected set; }

        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}
