using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceControl.Data.Map
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> type)
        {
            type.ToTable("User");
            type.Property(_ => _.UserId).HasColumnName("Id");
            type.Property(_ => _.Name).HasColumnName("Name");
            type.Property(_ => _.Login).HasColumnName("Login");
            type.Property(_ => _.Password).HasColumnName("Password");
            type.Property(_ => _.Email).HasColumnName("Email");

            type.HasKey(_ => new { _.UserId });
        }
    }
}
