using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Filters
{
    public class Filter
    {
        public bool IsFiltered { get; set; }

        public SearchIn? SearchIn { get; set; }
        public string[]? Domains { get; set; }
        public DateFilter? DateFilter { get; set; }
        public Language? Language { get; set; }
        public SortBy? SortBy { get; set; }
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public Source[]? Sources { get; set; }

        public string? q { get; set; }


    }
}
