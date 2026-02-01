using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Filters
{
    public class DateFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateFilter(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
}
