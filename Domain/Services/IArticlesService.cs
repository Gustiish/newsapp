using Domain.DTOs;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Domain.Services
{
    public interface IArticlesService
    {
        Task<ObservableCollection<ArticleDTO>> GetArticles(Filter filter);
    }
}
