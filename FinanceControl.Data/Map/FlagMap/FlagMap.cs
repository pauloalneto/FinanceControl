using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceControl.Data.Map
{
    public class FlagMap
    {
        public FlagMap(EntityTypeBuilder<Flag> type)
        {
            type.ToTable("Flag");
            type.Property(_ => _.FlagId).HasColumnName("Id");
            type.Property(_ => _.Name).HasColumnName("Name");

            type.HasKey(_ => new { _.FlagId });
        }
    }
}
