
using ApplicationLayer.Mapping;
using Domain.ApiHandling;
using Domain.DTOs;
using Domain.Filters;
using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApplicationLayer.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IApiService _service;
        private readonly ArticleToArticleDTOMapper _mapper;
        public ArticlesService(IApiService service, ArticleToArticleDTOMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ObservableCollection<ArticleDTO>> GetArticles(Filter filter)
        {
            Root articles = await _service.GetArticles(filter);
            return CreateListOfArticleDTOs(articles);
        }

        private ObservableCollection<ArticleDTO> CreateListOfArticleDTOs(Root articles)
        {
            ObservableCollection<ArticleDTO> DTOs = new ObservableCollection<ArticleDTO>();
            foreach (Article article in articles.articles)
            {
                DTOs.Add(_mapper.Map(article));
            }
            return DTOs;
        }
    }
}
