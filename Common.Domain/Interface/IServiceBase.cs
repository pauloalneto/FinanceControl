using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interface
{
    public interface IServiceBase<T, TF>
    {
        Task<IEnumerable<T>> GetByFilters(TF filters);
    }
}
