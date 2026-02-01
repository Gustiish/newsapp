namespace Domain.DTOs;

public class ArticleDTO
{
    public SourceDTO Source { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string URL { get; set; }
    public string UrlToImage { get; set; }
    public DateTime PublishedAt { get; set; }
    public string Content { get; set; }
}
