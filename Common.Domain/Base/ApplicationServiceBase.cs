using AutoMapper;
using Common.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Base
{
    public abstract class ApplicationServiceBase<T, TD> where TD : class
    {
        protected readonly IServiceBase<T> servicebase;
        protected readonly IMapper mapper;

        public ApplicationServiceBase(IServiceBase<T> servicebase, IMapper mapper)
        {
            this.servicebase = servicebase;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TD>> GetByFilters()
        {
            var result = await this.servicebase.GetByFilters();

            return this.MapperDomainToResult<TD>(result);
        }

        protected virtual IEnumerable<TDS> MapperDomainToResult<TDS>(IEnumerable<T> dataList)
        {
            var result = this.mapper.Map<IEnumerable<T>, IEnumerable<TDS>>(dataList);
            return result;
        }
    }
}
