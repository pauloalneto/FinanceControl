using AutoMapper;
using Common.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Base
{
    public abstract class ApplicationServiceBase<T, TD, TF> 
        where TF : class 
        where TD : class
    {
        protected readonly IServiceBase<T, TF> servicebase;
        protected readonly IMapper mapper;

        public ApplicationServiceBase(IServiceBase<T, TF> servicebase, IMapper mapper)
        {
            this.servicebase = servicebase;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<TD>> GetByFilters(FilterBase filters)
        {
            var result = await this.servicebase.GetByFilters(filters as TF);

            return this.MapperDomainToResult<TD>(result);
        }

        protected virtual IEnumerable<TDS> MapperDomainToResult<TDS>(IEnumerable<T> dataList)
        {
            var result = this.mapper.Map<IEnumerable<T>, IEnumerable<TDS>>(dataList);
            return result;
        }
    }
}
