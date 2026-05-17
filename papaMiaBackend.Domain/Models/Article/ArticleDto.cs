namespace papaMiaBackend.Domain.Models.Article;

public class ArticleDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
