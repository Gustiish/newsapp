using Domain.Filters;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ApiHandling
{
    public interface IApiService
    {
        Task<Root> GetArticles(Filter filter); 
    }
}
