using Common.Domain.Interface;
using FinanceControl.Domain.Entity;
using FinanceControl.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceControl.Domain.Interface.Repository
{
    public interface IFlagRepository : IRepository<Flag>
    {
        IQueryable<Flag> GetAllWithFilters(FlagFilter filters);
        Task<dynamic> GetDataCustom(FlagFilter filters);
    }
}
