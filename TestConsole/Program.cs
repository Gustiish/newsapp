

using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string ApiKey = "c7b0a875f0174931830c0aea7b67c2ee";
        string authHeader = "X-Api-Key";

        HttpRequestMessage request = new HttpRequestMessage();

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://newsapi.org/v2/everything");
        client.DefaultRequestHeaders.Add(authHeader, ApiKey);
        request.Method = new HttpMethod("GET");

        var response = client.Send(request);
     
    }
}