using Common.Dto;

namespace FinanceControl.Dto.Dto
{
    public class UserRoleDto : DtoBase
    {
        public virtual int UserId { get; set; }
        public virtual int RoleId { get; set; }

        public virtual UserDto User {get; set;}
        public virtual RoleDto Role {get; set;}

    }
}
