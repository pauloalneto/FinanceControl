using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceControl.Data.Map
{
    public class RoleMap
    {
        public RoleMap(EntityTypeBuilder<Role> type)
        {
            type.ToTable("Role");
            type.Property(_ => _.RoleId).HasColumnName("Id");
            type.Property(_ => _.Name).HasColumnName("Name");

            type.HasKey(_ => new { _.RoleId });
        }
    }
}
