using Common.Dto;

namespace FinanceControl.Dto.Dto
{
    public class FlagDto : DtoBase
    {
        public virtual int FlagId { get; set; }
        public virtual string Name { get; set; }
    }
}
