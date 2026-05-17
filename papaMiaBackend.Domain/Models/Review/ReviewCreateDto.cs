namespace papaMiaBackend.Domain.Models.Review;

public class ReviewCreateDto
{
    public int Rating { get; set; }
    public string Text { get; set; } = string.Empty;
}
