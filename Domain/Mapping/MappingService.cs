using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mapping
{
    public class MappingService
    {
        private readonly Dictionary<(Type Source, Type Destination), object> _mappers = new();

        public void RegisterMapper<TSource, TDestination>(IMapper<TSource, TDestination> mapper)
        {
            (Type, Type) key = (typeof(TSource), typeof(TDestination));
            _mappers[key] = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var key = (typeof(TSource), typeof(TDestination));
            if (_mappers.TryGetValue(key, out var mapper))
            {
                return ((IMapper<TSource, TDestination>)mapper).Map(source);
            }
            throw new InvalidOperationException($"No mapper registered for {typeof(TSource)} to {typeof(TDestination)}");


        }

    }
}
