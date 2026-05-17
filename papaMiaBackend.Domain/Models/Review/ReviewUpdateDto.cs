namespace papaMiaBackend.Domain.Models.Review;

public class ReviewUpdateDto
{
    public string AuthorName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsHidden { get; set; }
}
