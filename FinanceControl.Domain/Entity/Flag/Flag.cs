using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class Flag : FlagBase
    {

        public Flag()
        {
        }

        public Flag(int FlagId, string Name) : base(FlagId, Name)
        {
        }
    }
}
