
using Domain.DTOs;
using Domain.Mapping;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Mapping
{
    public class SourceToSourceDTOMapper : IMapper<Source, SourceDTO>
    {
        public SourceDTO Map(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new SourceDTO
            {
                Id = source.id,
                Name = source.name              
            };
        }
    }
}
