namespace papaMiaBackend.Domain.Models.Article;

public class ArticleCreateDto
{
    public string Text { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
