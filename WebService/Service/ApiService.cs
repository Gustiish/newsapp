using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.ApiHandling;
using Domain.Filters;

using Domain.Models;
using webservice.Api;


namespace webservice.Service
{
    public class ApiService : IApiService
    {
        private readonly NewsHttpClient _client;
        JsonSerializerOptions Options;
        public ApiService(NewsHttpClient client)
        {
            _client = client;
            Options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public async Task<Root> GetArticles(Filter filter)
        {
            HttpResponseMessage response = await _client.SendRequest(filter);
            var content = await CreateApiResponseAsync(response);
            if (content is null)
                throw new Exception("Could not get articles");

            return content;

        }

        private async Task<Root> CreateApiResponseAsync(HttpResponseMessage response)
        {
            var contentString = await response.Content.ReadAsStringAsync();

     

            return JsonSerializer.Deserialize<Root>(contentString, Options) ?? null;

          

        }

       

        
      
    }
}
