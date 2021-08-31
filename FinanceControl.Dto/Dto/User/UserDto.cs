using Common.Dto;
using System.Collections.Generic;

namespace FinanceControl.Dto.Dto
{
    public class UserDto : DtoBase
    {
        public virtual int UserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
    }
}
