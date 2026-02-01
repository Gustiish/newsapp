using Domain.Filters;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace webservice.Builders
{
    public class HttpRequestMessageBuilder 
    {

        private readonly UriBuilder uriBuilder;
        private readonly HttpRequestMessage message;
        private readonly Filter filter;
        private readonly NameValueCollection query;
        public HttpRequestMessageBuilder(Filter filter)
        {
            this.filter = filter;
            uriBuilder = new UriBuilder("https://newsapi.org/v2/everything");
            message = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
            query = HttpUtility.ParseQueryString(string.Empty);
        }

        public HttpRequestMessageBuilder AddPageSize()
        {
            query.Add("pageSize", "20");
            return this;
        }

        public HttpRequestMessageBuilder AddPage()
        {
            if (!string.IsNullOrWhiteSpace(filter.Page.ToString()))
            {
                query.Add("page", $"{filter.Page.ToString()}");
            }
            else
            {
                query.Add("page", "1");
            }
            return this;
        }

        public HttpRequestMessageBuilder AddKeyWords()
        {
            if (!string.IsNullOrWhiteSpace(filter.q))
            {
                query.Add("q", $"{filter.q.ToLowerInvariant()}");
            }
            else
            {
                query.Add("q", "business");
            }


            return this;
        }

        public HttpRequestMessageBuilder AddSearchIn()
        {
            if (filter.SearchIn != null)
                query.Add("searchIn", filter.SearchIn.ToString().ToLowerInvariant());

            return this;
        }

        public HttpRequestMessageBuilder AddDomains()
        {
            if (filter.Domains?.Any() == true)
                query.Add("domains", string.Join(",", filter.Domains).ToLowerInvariant());

            return this;
        }

        public HttpRequestMessageBuilder ExcludeDomains()
        {
            if (filter.Domains?.Any() == true)
                query.Add("excludeDomains", string.Join(",", filter.Domains).ToLowerInvariant());

            return this;
        }

        public HttpRequestMessageBuilder AddDates()
        {
            if (filter.DateFilter != null)
            {
                query.Add("from", filter.DateFilter.From.ToString("yyyy-MM-dd"));
                query.Add("to", filter.DateFilter.To.ToString("yyyy-MM-dd"));
            }

            return this;
        }

        public HttpRequestMessageBuilder AddLanguage()
        {
            if (filter.Language != null)
                query.Add("language", filter.Language.ToString().ToLowerInvariant());

            return this;
        }

        public HttpRequestMessageBuilder AddSortBy()
        {
            if (filter.SortBy != null)
                query.Add("sortBy", filter.SortBy.ToString().ToLowerInvariant());

            return this;
        }

    



        public HttpRequestMessage Build()
        {
            
            uriBuilder.Query = query.ToString();


            HttpRequestMessage message = new HttpRequestMessage();
            message.RequestUri = uriBuilder.Uri;
            return message;
        }
    }
}
