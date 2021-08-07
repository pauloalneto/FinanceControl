using Common.Domain.Interface;
using FinanceControl.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceControl.Domain.Interface.Repository
{
    public interface IFlagRepository : IRepository<Flag>
    {
        IQueryable<Flag> GetAllWithFilters();
    }
}
