using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mapping
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
