using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Domain.Entity
{
    public class FlagBase
    {
        public FlagBase()
        {
        }

        public FlagBase(int FlagId, string Name)
        {
            this.FlagId = FlagId;
            this.Name = Name;
        }

        public virtual int FlagId { get; protected set; }
        public virtual string Name { get; protected set; }

        public void SetarFlagId(int id)
        {
            this.FlagId = id;
        }

        public void SetarName(string name)
        {
            this.Name = name;
        }

    }
}
