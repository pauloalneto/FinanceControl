using Common.Dto;

namespace FinanceControl.Dto.Dto
{
    public class RoleDto : DtoBase
    {
        public virtual int RoleId { get; set; }
        public virtual string Name { get; set; }
    }
}
