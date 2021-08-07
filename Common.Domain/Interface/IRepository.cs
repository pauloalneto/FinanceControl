using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<List<T2>> ToListAsync<T2>(IQueryable<T2> source);
    }
}
