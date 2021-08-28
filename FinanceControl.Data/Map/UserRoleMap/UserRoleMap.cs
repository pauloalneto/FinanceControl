using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceControl.Data.Map
{
    public class UserRoleMap
    {
        public UserRoleMap(EntityTypeBuilder<UserRole> type)
        {
            type.ToTable("UserRole");
            type.Property(_ => _.UserId).HasColumnName("IdUser");
            type.Property(_ => _.RoleId).HasColumnName("IdRole");
 

            type.HasKey(_ => new { _.UserId, _.RoleId });
        }
    }
}
