using System.Collections.Generic;

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
