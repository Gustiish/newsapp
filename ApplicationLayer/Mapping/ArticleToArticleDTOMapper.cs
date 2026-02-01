
using Domain.DTOs;
using Domain.Mapping;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Mapping
{
    public class ArticleToArticleDTOMapper : IMapper<Article, ArticleDTO>
    {
        public ArticleDTO Map(Article article)
        {
            if (article == null)
                throw new NullReferenceException(nameof(article));
            return new ArticleDTO()
            {
                Author = article.author,
                Title = article.title,
                Description = article.description,
                URL = article.url,
                UrlToImage = article.urlToImage,
                PublishedAt = article.publishedAt,
                Content = article.content
            };
        }
    }
}
