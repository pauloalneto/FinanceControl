using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceControl.Application.Config
{
    public class AutoMapperConfigFinanceControl
    {
        public static Type[] RegisterMappings()
        {
            return new List<Type>
            {
                typeof(DomainDtoToProfileFinanceControl)
            }.ToArray();
        }
    }
}
