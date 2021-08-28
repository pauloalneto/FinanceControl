using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class User : UserBase
    {
        public ICollection<UserRole> CollectionUserRole { get; private set; }
        public User()
        {

        }

        public User(int userId) : base(userId)
        {

        }
    }
}
