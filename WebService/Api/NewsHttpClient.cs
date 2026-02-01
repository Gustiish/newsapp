
using Domain.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using webservice.Builders;

namespace webservice.Api
{
    public class NewsHttpClient 
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private const string AuthHeader = "X-Api-Key";
        private string ApiKey;

        public NewsHttpClient(IConfiguration config, HttpClient client)
        {
            _config = config;
            
            _client = client;
            ApiKey = _config["ApiKey"] ?? throw new Exception("Api key not found");
            AddAuthHeader();
        }

        public async  Task<HttpResponseMessage> SendRequest(Filter filter)
        {
            HttpRequestMessageBuilder requestBuilder = new HttpRequestMessageBuilder(filter);
            HttpRequestMessage message = requestBuilder.AddLanguage().AddPageSize().AddSearchIn().AddKeyWords().AddDates().AddDomains().AddSortBy().AddPage().AddPageSize().Build();
            
            
            var response = await _client.SendAsync(message);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode} : {response.StatusCode.ToString()}");

            return response;
        }

        private void AddAuthHeader()
        {
            _client.DefaultRequestHeaders.Add(AuthHeader, ApiKey);
            _client.DefaultRequestHeaders.Add("User-Agent", "MauiNewsApp/1.0");

        }
    }
}
