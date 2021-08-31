using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interface
{
    public interface IApplicationServiceBase<T>
    {
        Task<IEnumerable<T>> GetByFilters(FilterBase filters);
    }
}
