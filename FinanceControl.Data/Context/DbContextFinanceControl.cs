using FinanceControl.Data.Map;
using FinanceControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Data.Context
{
    public class DbContextFinanceControl : DbContext
    {
        public DbContextFinanceControl(DbContextOptions<DbContextFinanceControl> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new FlagMap(modelBuilder.Entity<Flag>());
            new UserMap(modelBuilder.Entity<User>());
        }
    }
}
