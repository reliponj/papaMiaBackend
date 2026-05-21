namespace papaMiaBackend.Domain.Models.Article;

public class ArticleUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
